using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class TestResultSynchronizationService : ITestResultSynchronizationService
    {
        public TestResultSynchronizationService()
        {

        }

        public TestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public ReadingSource NewReadingSource { get; set; }

        protected ResultReading<T> SynchronizeResultReading<T>(ResultReading<T> currentReading, ResultReading<T> newReading, DataRecorderMetaData dataRecorderMetaData)
        {
            if (currentReading == null && newReading == null) return null;

            if (currentReading == null)
            {
                if (newReading.Reading == null) newReading = null;
                else
                {
                    newReading.RecorderMetaData = new DataRecorderMetaData
                                                      {
                                                          DataRecorderCreator = dataRecorderMetaData.DataRecorderCreator,
                                                          DateCreated = dataRecorderMetaData.DateCreated
                                                      };
                }
                return newReading;
            }

            if (newReading != null)
            {

                newReading.Id = currentReading.Id;

                if (currentReading.Reading.Equals(newReading.Reading))
                {
                    return currentReading;
                }

                if (currentReading.ReadingSource == ReadingSource.Manual && newReading.ReadingSource == ReadingSource.Automatic)
                {
                    return currentReading;
                }

                if (newReading.ReadingSource == ReadingSource.Manual)
                {
                    if (newReading.Reading == null) return null;
                }
                else if (currentReading.ReadingSource == ReadingSource.Automatic && newReading.ReadingSource == ReadingSource.Automatic)
                {
                    if (newReading.Reading == null && currentReading.Reading != null) return currentReading;
                }

                newReading.RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = currentReading.RecorderMetaData.DataRecorderCreator,
                    DateCreated = currentReading.RecorderMetaData.DateCreated,
                    DataRecorderModifier = dataRecorderMetaData.DataRecorderCreator,
                    DateModified = dataRecorderMetaData.DateCreated
                };
            }
            else
            {
                if (currentReading.ReadingSource == ReadingSource.Manual && NewReadingSource == ReadingSource.Automatic)
                    return currentReading;
            }

            return newReading;
        }

        protected bool IsIncompleteReading<T>(CompoundResultReading<T> testResultReading)
        {
            if (testResultReading != null && testResultReading.Finding != null && testResultReading.Reading != null)
                return false;

            return true;
        }

        protected CompoundResultReading<T> SynchronizeResultReading<T>(CompoundResultReading<T> currentReading, CompoundResultReading<T> newReading, DataRecorderMetaData dataRecorderMetaData)
        {
            if (currentReading == null && newReading == null) return null;

            if (currentReading == null)
            {
                if (newReading.Reading == null && newReading.Finding == null) newReading = null;
                else
                {
                    newReading.RecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = dataRecorderMetaData.DataRecorderCreator,
                        DateCreated = dataRecorderMetaData.DateCreated
                    };
                }
                return newReading;
            }

            if (newReading != null)
            {
                newReading.Id = currentReading.Id;
                if (currentReading.Reading.Equals(newReading.Reading))
                {
                    if (currentReading.Finding != null && newReading.Finding != null &&
                        currentReading.Finding.Id == newReading.Finding.Id)
                        return currentReading;

                    if (currentReading.Finding == null && newReading.Finding == null) return currentReading;
                }

                if (currentReading.ReadingSource == ReadingSource.Manual && newReading.ReadingSource == ReadingSource.Automatic)
                {
                    return currentReading;
                }

                if (newReading.ReadingSource == ReadingSource.Manual && newReading.Reading == null && newReading.Finding == null)
                {
                    return null;
                }

                if (currentReading.ReadingSource == ReadingSource.Automatic && newReading.ReadingSource == ReadingSource.Automatic)
                {
                    if (newReading.Reading == null && currentReading.Reading != null)
                    {
                        return currentReading;
                    }
                }

                newReading.RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = currentReading.RecorderMetaData.DataRecorderCreator,
                    DateCreated = currentReading.RecorderMetaData.DateCreated,
                    DataRecorderModifier = dataRecorderMetaData.DataRecorderCreator,
                    DateModified = dataRecorderMetaData.DateCreated
                };
            }
            else
            {
                if (currentReading.ReadingSource == ReadingSource.Manual && NewReadingSource == ReadingSource.Automatic)
                    return currentReading;
            }

            return newReading;
        }

        protected TestResult SyncronizeTestResult(TestResult currentTestResult, TestResult newTestResult)
        {
            if (newTestResult.IncidentalFindings != null)
            {
                newTestResult.IncidentalFindings.ForEach(incFinding => incFinding.IncidentalFindingGroups.ForEach(ifd => ifd.GroupItems.ForEach(gi =>
                                                                    {
                                                                        gi.RecorderMetaData = new DataRecorderMetaData
                                                                                                    {
                                                                                                        DataRecorderCreator = newTestResult.DataRecorderMetaData.DataRecorderCreator,
                                                                                                        DateCreated = newTestResult.DataRecorderMetaData.DateCreated
                                                                                                    };
                                                                    })));
            }

            newTestResult.ResultStatus.DataRecorderMetaData = new DataRecorderMetaData
                                                                  {
                                                                      DataRecorderCreator = newTestResult.DataRecorderMetaData.DataRecorderCreator,
                                                                      DateCreated = newTestResult.DataRecorderMetaData.DateCreated
                                                                  };

            if (currentTestResult != null)
            {
                newTestResult.ResultStatus.DataRecorderMetaData = new DataRecorderMetaData
                                                                      {
                                                                          DataRecorderCreator = currentTestResult.ResultStatus.DataRecorderMetaData.DataRecorderCreator,
                                                                          DateCreated = currentTestResult.ResultStatus.DataRecorderMetaData.DateCreated,
                                                                          DataRecorderModifier = newTestResult.DataRecorderMetaData.DataRecorderCreator,
                                                                          DateModified = newTestResult.DataRecorderMetaData.DateCreated
                                                                      };

                if (currentTestResult.IncidentalFindings != null && newTestResult.IncidentalFindings != null)
                {
                    var groupItems = currentTestResult.IncidentalFindings.SelectMany(ifn => ifn.IncidentalFindingGroups.SelectMany(ifd => ifd.GroupItems));
                    if (groupItems.Count() > 0)
                    {
                        newTestResult.IncidentalFindings.Where(incFinding => incFinding.IncidentalFindingGroups != null).ToList().ForEach(incFinding => incFinding.IncidentalFindingGroups.ForEach(ifd => ifd.GroupItems.ForEach(gi =>
                        {
                            var giInDb = groupItems.Where(gidb => gidb.Id == gi.Id).FirstOrDefault();
                            gi.RecorderMetaData = new DataRecorderMetaData
                            {
                                DataRecorderCreator = giInDb.RecorderMetaData.DataRecorderCreator,
                                DateCreated = giInDb.RecorderMetaData.DateCreated,
                                DataRecorderModifier = newTestResult.DataRecorderMetaData.DataRecorderCreator,
                                DateModified = newTestResult.DataRecorderMetaData.DateCreated
                            };
                        })));
                    }
                }
            }

            return newTestResult;
        }

        protected TestResult SyncronizeTestResultForAutomaticUploadwithManual(TestResult currentTestResult, TestResult newTestResult)
        {
            if (currentTestResult == null) return newTestResult;

            if (currentTestResult.IncidentalFindings != null) newTestResult.IncidentalFindings = currentTestResult.IncidentalFindings;

            if (currentTestResult.UnableScreenReason != null) newTestResult.UnableScreenReason = currentTestResult.UnableScreenReason;

            newTestResult.ResultStatus.SelfPresent = currentTestResult.ResultStatus.SelfPresent;
            newTestResult.ConductedByOrgRoleUserId = currentTestResult.ConductedByOrgRoleUserId;
            newTestResult.EvaluatedbyOrgRoleUserId = currentTestResult.EvaluatedbyOrgRoleUserId;
            newTestResult.TechnicianNotes = currentTestResult.TechnicianNotes;

            return newTestResult;
        }

        protected bool SynchronizeForChangeReadingSource<T>(ReadingSource? expectedReadingSource, ResultReading<T> newReading)
        {
            if (newReading == null) return false;
            if (expectedReadingSource == null) return false;

            if (expectedReadingSource.Value != newReading.ReadingSource) return true;

            return false;
        }

        protected void SynchronizeResultReadingsForRecorderMetaData(TestResult testResult)
        {
            var list = GetAllResultReadingTypesfromTestResult(testResult);

            foreach (var obj in list)
            {
                if (obj is ResultReading<decimal?>)
                    CreateReadingRecorderMetadata((ResultReading<decimal?>)obj, testResult);
                else if (obj is ResultReading<decimal>)
                    CreateReadingRecorderMetadata((ResultReading<decimal>)obj, testResult);
                else if (obj is ResultReading<int?>)
                    CreateReadingRecorderMetadata((ResultReading<int?>)obj, testResult);
                else if (obj is ResultReading<int>)
                    CreateReadingRecorderMetadata((ResultReading<int>)obj, testResult);
                else if (obj is ResultReading<bool?>)
                    CreateReadingRecorderMetadata((ResultReading<bool?>)obj, testResult);
                else if (obj is ResultReading<bool>)
                    CreateReadingRecorderMetadata((ResultReading<bool>)obj, testResult);
                else if (obj is ResultReading<string>)
                    CreateReadingRecorderMetadata((ResultReading<string>)obj, testResult);
            }
        }

        protected void SynchornizeUnableToScreeandTechNotes(TestResult testResultinDb, TestResult newTestResult)
        {
            if (testResultinDb == null || newTestResult == null) return;

            if (newTestResult.TechNotesSource == ReadingSource.Automatic)
            {
                if (testResultinDb.TechNotesSource == ReadingSource.Manual && !string.IsNullOrEmpty(testResultinDb.TechnicianNotes))
                {
                    newTestResult.TechNotesSource = ReadingSource.Manual;
                    newTestResult.TechnicianNotes = testResultinDb.TechnicianNotes;
                }
                else if (testResultinDb.TechNotesSource == ReadingSource.Automatic && string.IsNullOrEmpty(newTestResult.TechnicianNotes))
                {
                    newTestResult.TechnicianNotes = testResultinDb.TechnicianNotes;
                }
            }

            if (testResultinDb.UnableScreenReason != null && NewReadingSource == ReadingSource.Automatic && testResultinDb.UnableScreenReason.Where(ua => ua.ReadingSource == ReadingSource.Manual).Count() > 0)
            {
                newTestResult.UnableScreenReason = testResultinDb.UnableScreenReason;
            }
            else if (newTestResult.UnableScreenReason == null && testResultinDb.UnableScreenReason != null && NewReadingSource == ReadingSource.Automatic && testResultinDb.UnableScreenReason.Where(ua => ua.ReadingSource == ReadingSource.Manual).Count() < 1)
            {
                newTestResult.UnableScreenReason = testResultinDb.UnableScreenReason;
            }
        }

        private static IEnumerable<object> GetAllResultReadingTypesfromTestResult<T>(T obj)
        {
            var members = obj.GetType().GetMembers();
            var list = new List<object>();

            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo == null)
                    continue;
                try
                {
                    var prop = propInfo.GetValue(obj, null);
                    if (prop == null) continue;

                    if (propInfo.PropertyType.Name.ToLower().Contains("resultreading"))
                    {
                        list.Add(prop);
                    }
                    //else if (propInfo.PropertyType.Name.ToLower().Contains("generic.list") && propInfo.PropertyType.FullName.ToLower().Contains("resultreading"))
                    else if (prop is System.Collections.IList)
                    {
                        var collection = prop as System.Collections.IList;
                        list.AddRange(collection.Cast<object>().Where(variable => variable.GetType().ToString().ToLower().IndexOf("resultreading") >= 0));
                    }
                    else if (!propInfo.PropertyType.IsValueType)
                    {
                        var result = GetAllResultReadingTypesfromTestResult(prop);
                        if (result != null && result.Count() > 0)
                            list.AddRange(result);
                    }
                }
                catch
                {
                    continue;
                }

            }
            return list;
        }

        private static void CreateReadingRecorderMetadata<T>(ResultReading<T> obj, TestResult testResult)
        {
            if (obj != null)
            {
                obj.RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(testResult.DataRecorderMetaData.DataRecorderCreator.Id),
                    DateCreated = testResult.DataRecorderMetaData.DateCreated
                };
            }
        }

        public virtual TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            if (NewReadingSource == ReadingSource.Automatic && currentTestResult != null)// Syncing those which didn't come through Uploaded file
            {
                newTestResult = SyncronizeTestResultForAutomaticUploadwithManual(currentTestResult, newTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newTestResult;
        }

        public virtual TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            throw new NotImplementedException();
        }

        public virtual TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            throw new NotImplementedException();
        }

        public TestResult SynchronizePhysicianEvaluation(TestResult newTestResult, TestResult inDbTestResult)
        {
            if (inDbTestResult == null || newTestResult == null || inDbTestResult.PhysicianInterpretation == null || newTestResult.PhysicianInterpretation == null)
                return newTestResult;

            newTestResult.PhysicianInterpretation.Id = inDbTestResult.PhysicianInterpretation.Id;

            return newTestResult;
        }
    }

}