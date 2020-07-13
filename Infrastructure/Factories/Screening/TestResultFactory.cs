using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class TestResultFactory : ITestResultFactory
    {
        public TestResult CreateTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var testResult = CreateActualTestResult(customerEventScreeningTestsEntity);

            if (customerEventScreeningTestsEntity.CustomerEventReading != null && customerEventScreeningTestsEntity.CustomerEventReading.Count > 0)
            {
                testResult.DataRecorderMetaData = new DataRecorderMetaData
                                                      {
                                                          DataRecorderCreator = new OrganizationRoleUser(customerEventScreeningTestsEntity.CustomerEventReading.FirstOrDefault().CreatedByOrgRoleUserId),
                                                          DateCreated = customerEventScreeningTestsEntity.CustomerEventReading.FirstOrDefault().CreatedOn,
                                                          DataRecorderModifier = new OrganizationRoleUser(customerEventScreeningTestsEntity.CustomerEventReading.FirstOrDefault().CreatedByOrgRoleUserId),
                                                          DateModified = DateTime.Now
                                                      };
            }


            var customerEventTestState = customerEventScreeningTestsEntity.CustomerEventTestState.SingleOrDefault();
            if (customerEventTestState != null)
            {
                testResult.ResultStatus = new TestResultState(customerEventTestState.CustomerEventTestStateId)
                                              {
                                                  SelfPresent = customerEventTestState.SelfPresent,
                                                  TestNotPerformed = customerEventTestState.IsTestNotPerformed,
                                                  IsPriorityInQueue = customerEventTestState.IsPriorityInQueue,
                                                  Status = customerEventTestState.IsPartial ? TestResultStatus.Incomplete : TestResultStatus.Complete,
                                                  StateNumber = customerEventTestState.EvaluationState,
                                                  DataRecorderMetaData = new DataRecorderMetaData
                                                                             {
                                                                                 DataRecorderCreator = new OrganizationRoleUser(customerEventTestState.CreatedByOrgRoleUserId),
                                                                                 DateCreated = customerEventTestState.CreatedOn,
                                                                                 DateModified = customerEventTestState.UpdatedOn,
                                                                                 DataRecorderModifier = customerEventTestState.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(customerEventTestState.UpdatedByOrgRoleUserId.Value) : null
                                                                             }

                                              };
                testResult.TechnicianNotes = customerEventTestState.TechnicianNotes;
                testResult.ConductedByOrgRoleUserId = customerEventTestState.ConductedByOrgRoleUserId.HasValue
                                                          ? customerEventTestState.ConductedByOrgRoleUserId.Value
                                                          : 0;
                testResult.EvaluatedbyOrgRoleUserId = customerEventTestState.EvaluatedByOrgRoleUserId.HasValue
                                                          ? customerEventTestState.EvaluatedByOrgRoleUserId.Value
                                                          : 0;
                testResult.ResultInterpretation = customerEventTestState.TestSummary;
                testResult.PathwayRecommendation = customerEventTestState.PathwayRecommendation;

            }
            else
            {
                testResult.ResultStatus = new TestResultState
                                              {
                                                  SelfPresent = false,
                                                  StateNumber = (int)TestResultStateNumber.NoResults
                                              };
            }

            testResult.PhysicianInterpretation = CreatePhysicianInterpretation(customerEventScreeningTestsEntity.CustomerEventTestPhysicianEvaluation.SingleOrDefault());

            // TODO: To improve in case, specific Unable Screen reasons are introduced
            if (customerEventScreeningTestsEntity.CustomerEventUnableScreenReason != null && customerEventScreeningTestsEntity.CustomerEventUnableScreenReason.Count > 0)
            {
                testResult.UnableScreenReason = new List<UnableScreenReason>();
                var allUnableScreenReason = new UnableToScreenStatusRepository().GetAllUnableToScreenReasons((long)testResult.TestType);

                customerEventScreeningTestsEntity.CustomerEventUnableScreenReason.ToList().ForEach(customerEventUnableScreenReason =>
                    {
                        var unableScreenReason = new UnableScreenReason(customerEventUnableScreenReason.CustomerEventUnableScreenReasonId) { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other };

                        if (customerEventUnableScreenReason.TestUnableScreenReasonId.HasValue)
                        {
                            var testUnableScreenReason = customerEventScreeningTestsEntity
                                    .TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason.ToList()
                                    .Find(testUnableScreenReasonEntity => testUnableScreenReasonEntity.TestUnableScreenReasonId == customerEventUnableScreenReason.TestUnableScreenReasonId);

                            if (testUnableScreenReason != null)
                            {
                                var selUnableScreenReason = allUnableScreenReason.Find(unableScreen => (long)unableScreen.Reason == testUnableScreenReason.UnableScreenReasonId);

                                if (selUnableScreenReason != null)
                                {
                                    unableScreenReason.Reason = (UnableToScreenReason)testUnableScreenReason.UnableScreenReasonId;
                                    unableScreenReason.Description = testUnableScreenReason.Description;
                                    unableScreenReason.DisplayName = selUnableScreenReason.DisplayName;
                                }
                            }
                        }

                        testResult.UnableScreenReason.Add(unableScreenReason);
                    });
            }

            // Filling Incidental Finding from Entity into the object
            if (customerEventScreeningTestsEntity.CustomerEventTestIncidentalFinding != null && customerEventScreeningTestsEntity.CustomerEventTestIncidentalFinding.Count() > 0)
            {
                testResult.IncidentalFindings = new List<IncidentalFinding>();
                customerEventScreeningTestsEntity.CustomerEventTestIncidentalFinding.ToList().ForEach(cetIncidentalFinding =>
                {
                    var selectedIncidentalFinding = customerEventScreeningTestsEntity.IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding.Where(finding =>
                        finding.IncidentalFindingsId == cetIncidentalFinding.IncidentalFindingId).FirstOrDefault();

                    testResult.IncidentalFindings.Add(new IncidentalFinding(cetIncidentalFinding.IncidentalFindingId)
                    {
                        CustomerEventTestIncidentalFindingId = cetIncidentalFinding.CustomerEventTestIncidentalFindingId,
                        Label = selectedIncidentalFinding.Label,
                        LocationCount = (selectedIncidentalFinding.LocationCount != null ? selectedIncidentalFinding.LocationCount.Value : 1)
                    });

                    if (cetIncidentalFinding.CustomerEventTestIncidentalFindingDetail != null)
                    {
                        testResult.IncidentalFindings.Last().IncidentalFindingGroups = new List<IncidentalFindingGroup>();

                        cetIncidentalFinding.CustomerEventTestIncidentalFindingDetail.ToList().ForEach(cetIncidentalFindingDetail =>
                        {
                            var incidentalFindingGroups = testResult.IncidentalFindings.Last().IncidentalFindingGroups;
                            incidentalFindingGroups.Add(new IncidentalFindingGroup());
                            incidentalFindingGroups.Last().GroupItems = new List<IncidentalFindingGroupItem>
                                                                            {
                                                                                new IncidentalFindingGroupItem(cetIncidentalFindingDetail.GroupItemId)
                                                                                {
                                                                                    CustomerEventTestGroupItemId = cetIncidentalFindingDetail.CustomerEventTestIncidentalFindingDetailId,
                                                                                    Label = cetIncidentalFindingDetail.IncidentalFindingReadingGroupItem.Label,
                                                                                    Value = cetIncidentalFindingDetail.Value ?? string.Empty,
                                                                                    Location = cetIncidentalFindingDetail.Location,
                                                                                    RecorderMetaData = new DataRecorderMetaData
                                                                                    {
                                                                                        DataRecorderCreator = new OrganizationRoleUser(cetIncidentalFindingDetail.CreatedByOrgRoleUserId.Value),
                                                                                        DateCreated = cetIncidentalFindingDetail.CreatedOn.Value,
                                                                                        DateModified = cetIncidentalFindingDetail.UpdatedOn,
                                                                                        DataRecorderModifier = cetIncidentalFindingDetail.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(cetIncidentalFindingDetail.UpdatedByOrgRoleUserId.Value) : null
                                                                                    }
                                                                                }
                                                                            };
                        });
                    }
                });
            }

            testResult.TestNotPerformed = CreateTestNotPerformed(customerEventScreeningTestsEntity.TestNotPerformed.SingleOrDefault());

            testResult.TestPerformedExternally = CreateTestPerformedExternally(customerEventScreeningTestsEntity.TestPerformedExternally.SingleOrDefault());

            return testResult;
        }


        public List<TestResult> CreateTestResults(List<CustomerEventScreeningTestsEntity> customerEventScreeningTestsEntities)
        {
            var testResults = new List<TestResult>();
            customerEventScreeningTestsEntities.ForEach(customerTestResult => testResults.Add(CreateTestResult(customerTestResult)));
            return testResults;
        }

        public CustomerEventScreeningTestsEntity CreateTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            CustomerEventScreeningTestsEntity customerEventScreeningEntity = CreateActualTestResultEntity(testResult, testReadingReadingPairs);

            if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
            {
                //customerEventScreeningEntity.CustomerEventUnableScreenReason = new EntityCollection<CustomerEventUnableScreenReasonEntity>();
                testResult.UnableScreenReason.ForEach(unableScreenReason =>
                    {
                        // ReSharper disable ConvertToLambdaExpression
                        customerEventScreeningEntity.CustomerEventUnableScreenReason.Add(new CustomerEventUnableScreenReasonEntity
                                                                                             {
                                                                                                 CustomerEventUnableScreenReasonId = unableScreenReason.Id,
                                                                                                 //TestUnableScreenReasonId = unableScreenReason.Reason != UnableToScreenReason.Other ? (byte?)new TestResultService().GetTestUnableScreenReasonId((int)testResult.TestType, (int)unableScreenReason.Reason) : null,
                                                                                                 TestUnableScreenReasonId = (byte?)new TestResultService().GetTestUnableScreenReasonId((int)testResult.TestType, (int)unableScreenReason.Reason),
                                                                                                 CreatedByOrgRoleUserId = testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                                                                                                 CreatedOn = testResult.DataRecorderMetaData.DateCreated
                                                                                             });
                        // ReSharper restore ConvertToLambdaExpression
                    });

            }

            var customerEventTestStates = new List<CustomerEventTestStateEntity>
                                            {
                                                    new CustomerEventTestStateEntity
                                                    {
                                                        CustomerEventTestStateId = testResult.ResultStatus.Id,
                                                        EvaluationState =
                                                            Convert.ToByte(testResult.ResultStatus.StateNumber),
                                                        SelfPresent = testResult.ResultStatus.SelfPresent,
                                                        IsPriorityInQueue = testResult.ResultStatus.IsPriorityInQueue,
                                                        IsCritical = testResult.ResultStatus.SelfPresent,
                                                        IsPartial = (testResult.ResultStatus.Status == TestResultStatus.Incomplete) ? true : false,
                                                        TechnicianNotes = testResult.TechnicianNotes,
                                                        ConductedByOrgRoleUserId = testResult.ConductedByOrgRoleUserId > 0 ? (long?)testResult.ConductedByOrgRoleUserId : null,
                                                        EvaluatedByOrgRoleUserId = testResult.EvaluatedbyOrgRoleUserId > 0 ? (long?)testResult.EvaluatedbyOrgRoleUserId : null,
                                                        TestSummary = testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical ? (testResult.ResultStatus.SelfPresent ? (long)ResultInterpretation.Critical : (long) ResultInterpretation.Urgent) : testResult.ResultInterpretation,
                                                        PathwayRecommendation = testResult.PathwayRecommendation,
                                                        CreatedByOrgRoleUserId =
                                                            testResult.ResultStatus.DataRecorderMetaData.DataRecorderCreator.Id,
                                                        CreatedOn = testResult.ResultStatus.DataRecorderMetaData.DateCreated,
                                                        UpdatedByOrgRoleUserId = testResult.ResultStatus.DataRecorderMetaData != null && testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier != null ? (long?)testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier.Id : null,
                                                        UpdatedOn = testResult.ResultStatus.DataRecorderMetaData != null && testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier != null ? testResult.ResultStatus.DataRecorderMetaData.DateModified : null
                                                    }
                                              };

            customerEventScreeningEntity.CustomerEventTestState.AddRange(customerEventTestStates);

            if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Count > 0)
            {
                var customerEventTestIncidentalFindingEntities = new List<CustomerEventTestIncidentalFindingEntity>();

                testResult.IncidentalFindings.ForEach(incidentalFinding =>
                {
                    customerEventTestIncidentalFindingEntities.Add(new CustomerEventTestIncidentalFindingEntity(incidentalFinding.CustomerEventTestIncidentalFindingId)
                    {
                        IncidentalFindingId = incidentalFinding.Id,
                        CreatedByOrgRoleUserId = testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                        CreatedOn = testResult.DataRecorderMetaData.DateCreated
                    });

                    if (incidentalFinding.IncidentalFindingGroups != null && incidentalFinding.IncidentalFindingGroups.Count > 0)
                    {
                        var customerEventTestIncidentalFindingDetails = new EntityCollection<CustomerEventTestIncidentalFindingDetailEntity>();
                        incidentalFinding.IncidentalFindingGroups.ForEach(incidentalFindingGroups => incidentalFindingGroups.GroupItems
                                                           .ForEach(groupItem => customerEventTestIncidentalFindingDetails.Add(new CustomerEventTestIncidentalFindingDetailEntity(groupItem.CustomerEventTestGroupItemId)
                                                                                {
                                                                                    GroupItemId = groupItem.Id,
                                                                                    Value = groupItem.Value,
                                                                                    CreatedByOrgRoleUserId = groupItem.RecorderMetaData.DataRecorderCreator.Id,
                                                                                    UpdatedByOrgRoleUserId = groupItem.RecorderMetaData.DataRecorderModifier != null ? (long?)groupItem.RecorderMetaData.DataRecorderModifier.Id : null,
                                                                                    CreatedOn = testResult.DataRecorderMetaData.DateCreated,
                                                                                    UpdatedOn = testResult.DataRecorderMetaData.DateCreated,
                                                                                    Location = groupItem.Location
                                                                                })));

                        customerEventTestIncidentalFindingEntities.Last().CustomerEventTestIncidentalFindingDetail.AddRange(customerEventTestIncidentalFindingDetails);
                    }
                });

                customerEventScreeningEntity.CustomerEventTestIncidentalFinding.AddRange(customerEventTestIncidentalFindingEntities);
            }

            var customerEventTestPhysicianEvaluation = CreatePhysicianEvaluationEntity(testResult.PhysicianInterpretation);
            if (customerEventTestPhysicianEvaluation != null)
            {
                customerEventScreeningEntity.CustomerEventTestPhysicianEvaluation.Add(customerEventTestPhysicianEvaluation);
            }

            var testNotPerformedEntity = CreateTestNotPerformedEntity(testResult.TestNotPerformed, testResult);

            if (testNotPerformedEntity != null)
            {
                customerEventScreeningEntity.TestNotPerformed.Add(testNotPerformedEntity);
            }

            var testPerformedExternallyEntity = CreateTestPerformedExternallyEntity(testResult.TestPerformedExternally, testResult);

            if (testPerformedExternallyEntity != null)
            {
                customerEventScreeningEntity.TestPerformedExternally.Add(testPerformedExternallyEntity);
            }

            return customerEventScreeningEntity;
        }

        public List<CustomerEventScreeningTestsEntity> CreateTestResultEntities(List<TestResult> testResults)
        {
            throw new NotImplementedException();
        }

        private static PhysicianInterpretation CreatePhysicianInterpretation(CustomerEventTestPhysicianEvaluationEntity customerEventPhysicianEvaluation)
        {
            if (customerEventPhysicianEvaluation != null)
            {
                return new PhysicianInterpretation(customerEventPhysicianEvaluation.CustomerEventTestPhysicianEvaluationId)
                {
                    Remarks = customerEventPhysicianEvaluation.PhysicianRemarks,
                    IsCritical = customerEventPhysicianEvaluation.IsCritical,
                    FollowUp = customerEventPhysicianEvaluation.IsFollowUpWithPhysician,
                    RecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = new OrganizationRoleUser(customerEventPhysicianEvaluation.CreatedByOrgRoleUserId),
                        DateCreated = customerEventPhysicianEvaluation.CreatedOn,
                        DateModified = customerEventPhysicianEvaluation.UpdatedOn,
                        DataRecorderModifier = customerEventPhysicianEvaluation.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(customerEventPhysicianEvaluation.UpdatedByOrgRoleUserId.Value) : null
                    }
                };
            }
            return null;
        }

        private static CustomerEventTestPhysicianEvaluationEntity CreatePhysicianEvaluationEntity(PhysicianInterpretation physicianInterpretation)
        {
            if (physicianInterpretation != null)
            {

                var entity = new CustomerEventTestPhysicianEvaluationEntity(physicianInterpretation.Id)
                {
                    PhysicianRemarks = physicianInterpretation.Remarks,
                    IsFollowUpWithPhysician = physicianInterpretation.FollowUp,
                    IsCritical = physicianInterpretation.IsCritical
                };

                if (physicianInterpretation.RecorderMetaData != null)
                {
                    entity.CreatedByOrgRoleUserId = physicianInterpretation.RecorderMetaData.DataRecorderCreator.Id;
                    entity.CreatedOn = physicianInterpretation.RecorderMetaData.DateCreated;
                    entity.UpdatedByOrgRoleUserId = physicianInterpretation.RecorderMetaData.DataRecorderModifier != null ? (long?)physicianInterpretation.RecorderMetaData.DataRecorderModifier.Id : null;
                    entity.UpdatedOn = physicianInterpretation.RecorderMetaData.DateModified;
                }

                return entity;
            }
            return null;
        }

        public virtual TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventTestsEntity)
        {
            return new TestResult((TestType)customerEventTestsEntity.TestId, customerEventTestsEntity.CustomerEventScreeningTestId);
        }

        public virtual CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            return new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (long)testResult.TestType };
        }

        protected File GetFileObjectfromEntity(Int64 fileId, List<FileEntity> fileEntities)
        {
            var file = new File(fileId);
            var selectedEntity = fileEntities.Find(entity => entity.FileId == fileId);
            if (selectedEntity != null)
            {
                file.Path = selectedEntity.Path;
                file.Type = (FileType)selectedEntity.Type;
            }
            return file;
        }

        protected StandardFinding<int> CreateFindingObject(CustomerEventTestStandardFindingEntity customerEventTestStandardFindingEntity, List<StandardFinding<int?>> standardFindings, StandardFindingTestReadingEntity standardFindingTestReadingEntity, int? readingId)
        {
            if (readingId != null && standardFindingTestReadingEntity.ReadingId != readingId.Value) return null;

            var standardFindingEntity = standardFindings.ToList().FindAll(standardFinding => standardFinding.Id == standardFindingTestReadingEntity.StandardFindingId).FirstOrDefault();
            StandardFinding<int> finding = null;
            if (standardFindingEntity != null)
            {
                finding = new StandardFinding<int>(standardFindingEntity.Id)
                {
                    CustomerEventStandardFindingId =
                        customerEventTestStandardFindingEntity.
                        CustomerEventTestStandardFindingId,
                    Label =
                        standardFindingEntity.Label,
                    MaxValue = Convert.ToInt32(standardFindingEntity.MaxValue),
                    MinValue = Convert.ToInt32(standardFindingEntity.MinValue),
                    Description = standardFindingEntity.Description
                };
            }
            return finding;
        }

        protected ResultReading<string> CreateResultReadingforInputValues(int readingId, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var entity = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == readingId).LastOrDefault();
            if (entity == null) return null;
            var testReading = new ResultReading<String>(entity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = entity.Value,
                ReadingSource = entity.IsManual ? ReadingSource.Manual : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                                       {
                                           DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                                           DateCreated = entity.CreatedOn,
                                           DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null,
                                           DateModified = entity.UpdatedOn
                                       }
            };

            return testReading;
        }

        protected ResultReading<bool> CreateResultReading(int readingId, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var entity = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == readingId).LastOrDefault();
            if (entity == null) return null;
            var testReading = new ResultReading<bool>(entity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = string.IsNullOrEmpty(entity.Value) ? false : Convert.ToBoolean(entity.Value),
                ReadingSource = entity.IsManual
                                    ? ReadingSource.Manual
                                    : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                    DateCreated = entity.CreatedOn,
                    DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = entity.UpdatedOn
                }
            };

            return testReading;
        }

        protected ResultReading<bool?> CreateResultReadingforNullableBool(int readingId, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var entity = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == readingId).LastOrDefault();
            if (entity == null) return null;
            var testReading = new ResultReading<bool?>(entity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = string.IsNullOrEmpty(entity.Value) ? false : Convert.ToBoolean(entity.Value),
                ReadingSource = entity.IsManual
                                    ? ReadingSource.Manual
                                    : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                    DateCreated = entity.CreatedOn,
                    DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = entity.UpdatedOn
                }
            };

            return testReading;
        }

        protected ResultReading<int?> CreateResultReadingforNullableInt(int readingId, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var entity = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == readingId).LastOrDefault();
            if (entity == null || string.IsNullOrEmpty(entity.Value)) return null;

            var testReading = new ResultReading<int?>(entity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = string.IsNullOrEmpty(entity.Value) ? 0 : Convert.ToInt32(entity.Value),
                ReadingSource = entity.IsManual
                                    ? ReadingSource.Manual
                                    : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                    DateCreated = entity.CreatedOn,
                    DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = entity.UpdatedOn
                }
            };

            return testReading;
        }

        protected ResultReading<int> CreateResultReadingforInt(int readingId, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var entity = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == readingId).LastOrDefault();
            if (entity == null || string.IsNullOrEmpty(entity.Value)) return null;

            var testReading = new ResultReading<int>(entity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = string.IsNullOrEmpty(entity.Value) ? 0 : Convert.ToInt32(entity.Value),
                ReadingSource = entity.IsManual
                                    ? ReadingSource.Manual
                                    : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                    DateCreated = entity.CreatedOn,
                    DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = entity.UpdatedOn
                }
            };

            return testReading;
        }

        protected ResultReading<decimal?> CreateResultReadingforNullableDecimal(int readingId, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var entity = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == readingId).LastOrDefault();
            if (entity == null || string.IsNullOrEmpty(entity.Value)) return null;

            var testReading = new ResultReading<decimal?>(entity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = string.IsNullOrEmpty(entity.Value) ? 0 : Convert.ToDecimal(entity.Value),
                ReadingSource = entity.IsManual
                                    ? ReadingSource.Manual
                                    : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                    DateCreated = entity.CreatedOn,
                    DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = entity.UpdatedOn
                }
            };

            return testReading;
        }

        protected ResultReading<string> CreateResultReadingforString(int readingId, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var entity = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == readingId).LastOrDefault();
            if (entity == null || string.IsNullOrEmpty(entity.Value)) return null;

            var testReading = new ResultReading<string>(entity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = entity.Value,
                ReadingSource = entity.IsManual
                                    ? ReadingSource.Manual
                                    : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                    DateCreated = entity.CreatedOn,
                    DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = entity.UpdatedOn
                }
            };

            return testReading;
        }

        protected CustomerEventReadingEntity CreateEventReadingEntity(ResultReading<int?> testReading, int readingId, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            if (testReading == null || testReading.Reading == null) return null;
            var readingEntity = new CustomerEventReadingEntity
            {
                TestReadingId =
                    testReadingReadingPairs.Find(testReadingReadingPair =>
                                                 (testReadingReadingPair.
                                                      FirstValue == readingId)).SecondValue,
                CustomerEventReadingId =
                    Convert.ToInt32(testReading.Id),
                Value = testReading.Reading.Value.ToString(),
                IsManual = testReading.ReadingSource == ReadingSource.Manual,
                CreatedByOrgRoleUserId =
                    testReading.RecorderMetaData.DataRecorderCreator.Id,
                CreatedOn = testReading.RecorderMetaData.DateCreated,
                UpdatedByOrgRoleUserId = testReading.RecorderMetaData.DataRecorderModifier != null ? (long?)testReading.RecorderMetaData.DataRecorderModifier.Id : null,
                UpdatedOn = testReading.RecorderMetaData.DateModified
            };

            return readingEntity;
        }


        protected CustomerEventReadingEntity CreateEventReadingEntitywithNullReading<T>(ResultReading<T> testReading, int readingId, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            if (testReading == null) return null;
            var readingEntity = new CustomerEventReadingEntity
            {
                TestReadingId =
                    testReadingReadingPairs.Find(testReadingReadingPair =>
                                                 (testReadingReadingPair.
                                                      FirstValue == readingId)).SecondValue,
                CustomerEventReadingId =
                    Convert.ToInt32(testReading.Id),
                Value = string.Empty,
                IsManual = testReading.ReadingSource == ReadingSource.Manual,
                CreatedByOrgRoleUserId =
                    testReading.RecorderMetaData.DataRecorderCreator.Id,
                CreatedOn = testReading.RecorderMetaData.DateCreated,
                UpdatedByOrgRoleUserId = testReading.RecorderMetaData.DataRecorderModifier != null ? (long?)testReading.RecorderMetaData.DataRecorderModifier.Id : null,
                UpdatedOn = testReading.RecorderMetaData.DateModified
            };

            return readingEntity;
        }

        protected CustomerEventReadingEntity CreateEventReadingEntity(ResultReading<int> testReading, int readingId, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            if (testReading == null) return null;
            var readingEntity = new CustomerEventReadingEntity
            {
                TestReadingId =
                    testReadingReadingPairs.Find(testReadingReadingPair =>
                                                 (testReadingReadingPair.
                                                      FirstValue == readingId)).SecondValue,
                CustomerEventReadingId =
                    Convert.ToInt32(testReading.Id),
                Value = testReading.Reading.ToString(),
                IsManual = testReading.ReadingSource == ReadingSource.Manual,
                CreatedByOrgRoleUserId =
                    testReading.RecorderMetaData.DataRecorderCreator.Id,
                CreatedOn = testReading.RecorderMetaData.DateCreated,
                UpdatedByOrgRoleUserId = testReading.RecorderMetaData.DataRecorderModifier != null ? (long?)testReading.RecorderMetaData.DataRecorderModifier.Id : null,
                UpdatedOn = testReading.RecorderMetaData.DateModified
            };

            return readingEntity;
        }

        protected CustomerEventReadingEntity CreateEventReadingEntity(ResultReading<decimal?> testReading, int readingId, List<OrderedPair<int, int>> testReadingReadingPairs, bool exceptNullReading = false)
        {
            if (testReading == null || (!exceptNullReading && testReading.Reading == null)) return null;

            var readingEntity = new CustomerEventReadingEntity
            {
                TestReadingId =
                    testReadingReadingPairs.Find(testReadingReadingPair =>
                                                 (testReadingReadingPair.
                                                      FirstValue == readingId)).SecondValue,
                CustomerEventReadingId =
                    Convert.ToInt32(testReading.Id),
                Value = testReading.Reading == null ? null : testReading.Reading.Value.ToString(),
                IsManual = testReading.ReadingSource == ReadingSource.Manual,
                CreatedByOrgRoleUserId =
                    testReading.RecorderMetaData.DataRecorderCreator.Id,
                CreatedOn = testReading.RecorderMetaData.DateCreated,
                UpdatedByOrgRoleUserId = testReading.RecorderMetaData.DataRecorderModifier != null ? (long?)testReading.RecorderMetaData.DataRecorderModifier.Id : null,
                UpdatedOn = testReading.RecorderMetaData.DateModified
            };

            return readingEntity;
        }

        protected CustomerEventReadingEntity CreateEventReadingEntity(ResultReading<String> testReading, int readingId, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            if (testReading == null) return null;
            var readingEntity = new CustomerEventReadingEntity
                                    {
                                        TestReadingId =
                                                    testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                                 (testReadingReadingPair.
                                                                                      FirstValue == readingId)).SecondValue,
                                        CustomerEventReadingId =
                                            Convert.ToInt32(testReading.Id),
                                        Value = testReading.Reading,
                                        IsManual = testReading.ReadingSource == ReadingSource.Manual,
                                        CreatedByOrgRoleUserId =
                                            testReading.RecorderMetaData.DataRecorderCreator.Id,
                                        CreatedOn = testReading.RecorderMetaData.DateCreated,
                                        UpdatedByOrgRoleUserId = testReading.RecorderMetaData.DataRecorderModifier != null ? (long?)testReading.RecorderMetaData.DataRecorderModifier.Id : null,
                                        UpdatedOn = testReading.RecorderMetaData.DateModified
                                    };

            return readingEntity;
        }

        protected CustomerEventReadingEntity CreateEventReadingEntity(ResultReading<Boolean> testReading, int readingId, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            if (testReading == null) return null;
            var readingEntity = new CustomerEventReadingEntity
                                    {
                                        TestReadingId =
                                                    testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                                 (testReadingReadingPair.
                                                                                      FirstValue == readingId)).SecondValue,
                                        CustomerEventReadingId =
                                            Convert.ToInt32(testReading.Id),
                                        Value = testReading.Reading.ToString(),
                                        IsManual = testReading.ReadingSource == ReadingSource.Manual,
                                        CreatedByOrgRoleUserId =
                                            testReading.RecorderMetaData.DataRecorderCreator.Id,
                                        CreatedOn = testReading.RecorderMetaData.DateCreated,
                                        UpdatedByOrgRoleUserId = testReading.RecorderMetaData.DataRecorderModifier != null ? (long?)testReading.RecorderMetaData.DataRecorderModifier.Id : null,
                                        UpdatedOn = testReading.RecorderMetaData.DateModified
                                    };

            return readingEntity;
        }

        protected CustomerEventReadingEntity CreateEventReadingEntity(ResultReading<bool?> testReading, int readingId, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            if (testReading == null || testReading.Reading == null) return null;
            var readingEntity = new CustomerEventReadingEntity
                                    {
                                        TestReadingId =
                                            testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                         (testReadingReadingPair.
                                                                              FirstValue == readingId)).SecondValue,
                                        CustomerEventReadingId =
                                            Convert.ToInt32(testReading.Id),
                                        Value = testReading.Reading.Value.ToString(),
                                        IsManual = testReading.ReadingSource == ReadingSource.Manual,
                                        CreatedByOrgRoleUserId =
                                            testReading.RecorderMetaData.DataRecorderCreator.Id,
                                        CreatedOn = testReading.RecorderMetaData.DateCreated,
                                        UpdatedByOrgRoleUserId = testReading.RecorderMetaData.DataRecorderModifier != null ? (long?)testReading.RecorderMetaData.DataRecorderModifier.Id : null,
                                        UpdatedOn = testReading.RecorderMetaData.DateModified
                                    };

            return readingEntity;
        }

        //protected long? GetResultInterpretationfortheFinding(int testId, int? readingId, long findingId)
        //{
        //    var service = new TestResultService();
        //    var findings = readingId.HasValue ? service.GetAllStandardFindings<decimal>(testId, readingId.Value) : service.GetAllStandardFindings<decimal>(testId);

        //    if (findings != null && findings.Count > 0)
        //    {
        //        var finding = findings.Where(f => f.Id == findingId).SingleOrDefault();
        //        return finding != null ? (long?)finding.ResultInterpretation : null;
        //    }
        //    return null;
        //}


        protected StandardFinding<decimal> GetSelectedStandardFinding(int testId, int? readingId, long findingId)
        {
            var service = new TestResultService();
            var findings = readingId.HasValue ? service.GetAllStandardFindings<decimal>(testId, readingId.Value) : service.GetAllStandardFindings<decimal>(testId);

            if (findings != null && findings.Count > 0)
            {
                var finding = findings.Where(f => f.Id == findingId).SingleOrDefault();
                return finding;
            }
            return null;
        }

        private TestNotPerformed CreateTestNotPerformed(TestNotPerformedEntity testNotPerformed)
        {
            if (testNotPerformed == null) return null;

            return new TestNotPerformed
            {
                Id = testNotPerformed.Id,
                CustomerEventScreeningTestId = testNotPerformed.CustomerEventScreeningTestId,
                TestNotPerformedReasonId = testNotPerformed.TestNotPerformedReasonId,
                Notes = testNotPerformed.Notes,
                IsManual = testNotPerformed.IsManual,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(testNotPerformed.CreatedBy),
                    DateCreated = testNotPerformed.CreatedOn,
                    DateModified = testNotPerformed.UpdatedOn,
                    DataRecorderModifier = testNotPerformed.UpdatedBy.HasValue ? new OrganizationRoleUser(testNotPerformed.UpdatedBy.Value) : null
                }
            };

        }

        private TestNotPerformedEntity CreateTestNotPerformedEntity(TestNotPerformed testNotPerformed, TestResult testResult)
        {
            if (testNotPerformed != null)
            {
                var entity = new TestNotPerformedEntity(testNotPerformed.Id)
                {
                    CustomerEventScreeningTestId = testNotPerformed.CustomerEventScreeningTestId,
                    TestNotPerformedReasonId = testNotPerformed.TestNotPerformedReasonId,
                    Notes = testNotPerformed.Notes,
                    IsManual = testNotPerformed.IsManual,
                    CreatedBy = testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                    CreatedOn = testResult.DataRecorderMetaData.DateCreated,
                    UpdatedBy = testResult.ResultStatus.DataRecorderMetaData != null && testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier != null ? (long?)testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier.Id : null,
                    UpdatedOn = testResult.ResultStatus.DataRecorderMetaData != null && testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier != null ? testResult.ResultStatus.DataRecorderMetaData.DateModified : null
                };

                return entity;
            }
            return null;
        }

        private TestPerformedExternally CreateTestPerformedExternally(TestPerformedExternallyEntity testPerformedExternally)
        {
            if (testPerformedExternally == null) return null;

            return new TestPerformedExternally
            {
                Id = testPerformedExternally.Id,
                CustomerEventScreeningTestId = testPerformedExternally.CustomerEventScreeningTestId,
                EntryCompleted = testPerformedExternally.EntryCompleted,
                ResultEntryTypeId = testPerformedExternally.ResultEntryTypeId,
                CreatedBy = testPerformedExternally.CreatedBy,
                CreatedDate = testPerformedExternally.CreatedDate,
                ModifiedBy = testPerformedExternally.ModifiedBy,
                ModifiedDate = testPerformedExternally.ModifiedDate,
            };

        }

        private TestPerformedExternallyEntity CreateTestPerformedExternallyEntity(TestPerformedExternally testPerformedExternally, TestResult testResult)
        {
            if (testPerformedExternally == null) return null;

            return new TestPerformedExternallyEntity(testPerformedExternally.Id)
            {
                CustomerEventScreeningTestId = testPerformedExternally.CustomerEventScreeningTestId,
                EntryCompleted = testPerformedExternally.EntryCompleted,
                ResultEntryTypeId = testPerformedExternally.ResultEntryTypeId,
                CreatedBy = testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                CreatedDate = testResult.DataRecorderMetaData.DateCreated,
                ModifiedBy = testResult.ResultStatus.DataRecorderMetaData != null && testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier != null ? (long?)testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier.Id : null,
                ModifiedDate = testResult.ResultStatus.DataRecorderMetaData != null && testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier != null ? testResult.ResultStatus.DataRecorderMetaData.DateModified : null
            };
        }
    }
}
