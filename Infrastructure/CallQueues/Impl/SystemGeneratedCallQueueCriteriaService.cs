using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class SystemGeneratedCallQueueCriteriaService : ISystemGeneratedCallQueueCriteriaService
    {
        private readonly ISystemGeneratedCallQueueCriteriaRepository _systemGeneratedCallQueueCriteriaRepository;
        private readonly ISettings _settings; 
        public SystemGeneratedCallQueueCriteriaService(ISystemGeneratedCallQueueCriteriaRepository systemGeneratedCallQueueCriteriaRepository, ISettings settings, ICallQueueRepository callQueueRepository)
        {
            _systemGeneratedCallQueueCriteriaRepository = systemGeneratedCallQueueCriteriaRepository;
            _settings = settings; 
        }

        public IEnumerable<SystemGeneratedCallQueueCriteria> GetSystemGeneratedCallQueueCriteria(long callQueueId)
        {
            var criterias = _systemGeneratedCallQueueCriteriaRepository.GetQueueCriteriasByQueueId(callQueueId);

            return criterias;
        }
        public IEnumerable<SystemGeneratedCallQueueCriteria> GetSystemGeneratedCallQueueCriteriaNotGenerated(long callQueueId)
        {
            var criterias = _systemGeneratedCallQueueCriteriaRepository.GetSystemGeneratedCallQueueCriteriaNotGenerated(callQueueId);

            return criterias;
        }
        public SystemGeneratedCallQueueCriteria GetSystemGeneratedCallQueueCriteria(long callQueueId, long? organisationUserRoleId)
        {
            var criteria = _systemGeneratedCallQueueCriteriaRepository.GetQueueCriteria(callQueueId, organisationUserRoleId);
            return criteria;
        }

        public SystemGeneratedCallQueueCriteria UpdateEventQueueCriteria(FillEventQueueCriteriaEditModel model, long organizationRoleId)
        {
            SystemGeneratedCallQueueCriteria criteria;
            if (model.CriteriaId > 0)
            {
                criteria = _systemGeneratedCallQueueCriteriaRepository.GetById(model.CriteriaId);
                criteria.Percentage = model.Percentage;
                criteria.NoOfDays = model.NoOfDays;
                criteria.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(organizationRoleId);
                criteria.DataRecorderMetaData.DateModified = DateTime.Now;
                criteria.IsQueueGenerated = false; 
            }
            else
            {
                criteria = new SystemGeneratedCallQueueCriteria
                {
                    DataRecorderMetaData = new DataRecorderMetaData(new OrganizationRoleUser(organizationRoleId), DateTime.Now, null),
                    CallQueueId = model.CallQueueId,
                    Percentage = model.Percentage, 
                    NoOfDays = model.NoOfDays,
                    AssignedToOrgRoleUserId = organizationRoleId
                };
            }
            return _systemGeneratedCallQueueCriteriaRepository.Save(criteria);  
        }
        public SystemGeneratedCallQueueCriteria UpdateUpsellQueueCriteria(UpsellQueueCriteriaEditModel model, long organizationRoleId)
        {
            SystemGeneratedCallQueueCriteria criteria;
            if (model.CriteriaId > 0)
            {
                criteria = _systemGeneratedCallQueueCriteriaRepository.GetById(model.CriteriaId);

                criteria.Amount = model.Amount;
                criteria.NoOfDays = model.NoOfDays;
                criteria.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(organizationRoleId);
                criteria.DataRecorderMetaData.DateModified = DateTime.Now;
                criteria.IsQueueGenerated = false;
            }
            else
            {
                criteria = new SystemGeneratedCallQueueCriteria
                {
                    DataRecorderMetaData =
                        new DataRecorderMetaData(new OrganizationRoleUser(organizationRoleId), DateTime.Now, null),
                    CallQueueId = model.CallQueueId, 
                    Amount = model.Amount,
                    NoOfDays = model.NoOfDays,
                    AssignedToOrgRoleUserId = organizationRoleId
                };
            }
            return _systemGeneratedCallQueueCriteriaRepository.Save(criteria);
        }

        public SystemGeneratedCallQueueCriteria UpdateConfirmationQueueCriteria(ConfirmationQueueCriteriaEditModel model, long organizationRoleId)
        {
            SystemGeneratedCallQueueCriteria criteria;
            if (model.CriteriaId > 0)
            {
                criteria = _systemGeneratedCallQueueCriteriaRepository.GetById(model.CriteriaId);
                criteria.NoOfDays = model.NoOfDays;
                criteria.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(organizationRoleId);
                criteria.DataRecorderMetaData.DateModified = DateTime.Now;
                criteria.IsQueueGenerated = false;
            }
            else
            {
                criteria = new SystemGeneratedCallQueueCriteria
                {
                    DataRecorderMetaData = new DataRecorderMetaData(new OrganizationRoleUser(organizationRoleId), DateTime.Now, null),
                    CallQueueId = model.CallQueueId,
                    NoOfDays = model.NoOfDays,
                    AssignedToOrgRoleUserId = organizationRoleId
                };
            }
            return _systemGeneratedCallQueueCriteriaRepository.Save(criteria);
        }
        public SystemGeneratedCallQueueCriteria Save(SystemGeneratedCallQueueCriteria systemGeneratedCallQueueCriteria)
        {
            var criteria = _systemGeneratedCallQueueCriteriaRepository.Save(systemGeneratedCallQueueCriteria);
            return criteria;
        }
    }
}
