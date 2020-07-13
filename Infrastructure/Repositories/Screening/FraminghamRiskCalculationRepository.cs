using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Mappers.Screening;
using Falcon.Data.Linq;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;
using System;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    public class FraminghamRiskCalculationRepository : PersistenceRepository, 
        IFraminghamRiskCalculationRepository
    {
        private readonly IMapper<FraminghamCalculationSource,FraminghamCalculationSourceEntity> _mapper;

        public FraminghamRiskCalculationRepository()
        {
            _mapper = new FraminghamCalculationSourceMapper();
        }

        public List<FraminghamCalculationSource> GetFraminghamCalculationSource()
        {
            List<FraminghamCalculationSourceEntity> framinghamCalculationSourceEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                framinghamCalculationSourceEntities = linqMetaData.FraminghamCalculationSource.ToList();
            }
            return _mapper.MapMultiple(framinghamCalculationSourceEntities).ToList();
        }

        public decimal? GetFraminghamRiskforScoreRange(int score, bool isGenderMale)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                List<FraminghamScoreRangeEntity> framinghamScoreRangeEntities = linqMetaData.
                    FraminghamScoreRange.ToList();

                var framinghamScoreRange = framinghamScoreRangeEntities.Find(framinghamScoreRangeEntity =>
                {
                    if (framinghamScoreRangeEntity.MinValue != null && 
                        framinghamScoreRangeEntity.MaxValue != null)
                    {
                        if (framinghamScoreRangeEntity.MaxValue == score)
                        {
                            return true;
                        }
                    }
                    else if (framinghamScoreRangeEntity.MinValue != null && 
                        score >= framinghamScoreRangeEntity.MinValue)
                    {
                        return true;
                    }
                    else if (framinghamScoreRangeEntity.MaxValue != null && 
                        score <= framinghamScoreRangeEntity.MaxValue)
                    {
                        return true;
                    }
                    return false;
                });

                return isGenderMale ? framinghamScoreRange.MaleRiskScore : 
                    framinghamScoreRange.FemaleRiskScore;
            }
        }

        public OrderedPair<bool, bool> GetSmokerDiabeticInformation(long customerId)
        {
            OrderedPair<bool, bool> smokerDiabeticInformation;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var smokerDiabeticData = from healthInformation in linqMetaData.CustomerHealthInfo
                                         where healthInformation.CustomerId == customerId
                                         select new
                                         {
                                             Id = healthInformation.CustomerHealthQuestionId,
                                             Value = healthInformation.HealthQuestionAnswer
                                         };
                if (smokerDiabeticData.Count() <= 0)
                {
                    return null;
                }
                smokerDiabeticData = smokerDiabeticData.Where
                    (smokerDiabetic => smokerDiabetic.Id == 1025 || smokerDiabetic.Id == 1030);
                smokerDiabeticInformation = new OrderedPair<bool, bool>(false, false);
                foreach (var data in smokerDiabeticData)
                {
                    if (data.Id == 1025)
                    {
                        smokerDiabeticInformation.FirstValue = data.Value == "No" ? false : true;
                    }
                    if (data.Id == 1030)
                    {
                        smokerDiabeticInformation.SecondValue = data.Value == "No" ? false : true;
                    }
                }
            }
            return smokerDiabeticInformation;
        }

        public bool SaveSmokerDiabeticInformation(long customerId, bool isSmoker, bool isDiabetic)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var customerHealthInfoEntitities = new EntityCollection<CustomerHealthInfoEntity>();
                var smokerData = from healthInformation in linqMetaData.CustomerHealthInfo
                                 where
                                     healthInformation.CustomerId == customerId &&
                                     healthInformation.CustomerHealthQuestionId == 1025
                                 select healthInformation;

                if (smokerData.Count() <= 0)
                {
                    var customerHealthInfoEntity = new CustomerHealthInfoEntity
                    {
                        HealthQuestionAnswer = isSmoker ? "Yes" : "No",
                        CustomerId = customerId,
                        CustomerHealthQuestionId = 1025,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsNew = true
                    };
                    customerHealthInfoEntitities.Add(customerHealthInfoEntity);
                }
                else
                {
                    var customerHealthInfoEntity = new CustomerHealthInfoEntity
                    {
                        HealthQuestionAnswer = isSmoker ? "Yes" : "No",
                        CustomerId = customerId,
                        CustomerHealthQuestionId = 1025,
                        DateModified = DateTime.Now,
                        IsNew = false,
                        //CustomerHealthInfoQuestionId = smokerData.FirstOrDefault().
                        //    CustomerHealthInfoQuestionId
                    };
                    customerHealthInfoEntitities.Add(customerHealthInfoEntity);
                }

                var diabeticData = from healthInformation in linqMetaData.CustomerHealthInfo
                                   where
                                       healthInformation.CustomerId == customerId &&
                                       healthInformation.CustomerHealthQuestionId == 1030
                                   select healthInformation;
                if (diabeticData.Count() <= 0)
                {
                    var customerHealthInfoEntity = new CustomerHealthInfoEntity
                    {
                        HealthQuestionAnswer = isDiabetic ? "Yes" : "No",
                        CustomerId = customerId,
                        CustomerHealthQuestionId = 1030,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsNew = true
                    };
                    customerHealthInfoEntitities.Add(customerHealthInfoEntity);
                }
                else
                {
                    var customerHealthInfoEntity = new CustomerHealthInfoEntity
                    {
                        HealthQuestionAnswer = isDiabetic ? "Yes" : "No",
                        CustomerId = customerId,
                        CustomerHealthQuestionId = 1030,
                        DateModified = DateTime.Now,
                        IsNew = false,
                        //CustomerHealthInfoQuestionId = diabeticData.FirstOrDefault().
                        //    CustomerHealthInfoQuestionId
                    };
                    customerHealthInfoEntitities.Add(customerHealthInfoEntity);
                }
                return SaveData(customerHealthInfoEntitities);
            }
        }

        private bool SaveData(IEntityCollection2 customerHealthInfoEntitities)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (myAdapter.SaveEntityCollection(customerHealthInfoEntitities) > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}