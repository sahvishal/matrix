using System;
using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class ContentService : IContentService
    {
        private IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public ContentEditModel GetModel(long id)
        {
            var obj = _contentRepository.Get(id);
            var model = Mapper.Map<Content, ContentEditModel>(obj);
            return model;
        }

        public ContentEditModel SaveModel(ContentEditModel model, long orgRoleUserId)
        {
            var obj = Mapper.Map<ContentEditModel, Content>(model);

            if (model.Id > 0)
            {
                var inDb = _contentRepository.Get(model.Id);
                obj.DataRecorderMetaData = inDb.DataRecorderMetaData;
                obj.DataRecorderMetaData.DateModified = DateTime.Now;
                obj.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleUserId);
            }
            else
            {
                obj.DataRecorderMetaData = new DataRecorderMetaData
                                               {
                                                   DateCreated = DateTime.Now,
                                                   DataRecorderCreator = new OrganizationRoleUser(orgRoleUserId)
                                               };
            }

            obj = _contentRepository.Save(obj);
            return Mapper.Map<Content, ContentEditModel>(obj);
        }

        public ContentListModel GetListModel(ContentListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var objects = _contentRepository.Get(filter, pageNumber, pageSize, out totalRecords);
            var viewModels = Mapper.Map<IEnumerable<Content>, IEnumerable<ContentViewModel>>(objects);
            var model = new ContentListModel { Collection = viewModels, Filter = filter };
            return model;
        }
    }
}