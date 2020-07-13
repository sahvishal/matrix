using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    [DefaultImplementation]
    public class SafeComputerHistoryRepository : PersistenceRepository, ISafeComputerHistoryRepository
    {
        public IEnumerable<SafeComputerHistory> Get(long userLoginId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (userLoginId > 0)
                {
                    var list = (from c in linqMetaData.SafeComputerHistory where c.UserLoginId == userLoginId select c);
                    return list.Count() == 0 ? null : Mapper.Map<IEnumerable<SafeComputerHistoryEntity>, IEnumerable<SafeComputerHistory>>(list);
                }
                return null;
            }
        }
        public bool Save(SafeComputerHistory safeComputerHistory)
        {
            var safeComputerHistoryEntity = Mapper.Map<SafeComputerHistory, SafeComputerHistoryEntity>(safeComputerHistory);
            using (IDataAccessAdapter adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var list = (from c in linqMetaData.SafeComputerHistory where c.UserLoginId == safeComputerHistory.UserLoginId && !c.IsActive  select c);
                if (list.Count() != 0)
                { 
                    foreach (var computerHistoryEntity in list)
                    {
                        if (computerHistoryEntity.BrowserType == safeComputerHistory.BrowserType &&
                            computerHistoryEntity.ComputerIp == safeComputerHistory.ComputerIp)
                        {
                            safeComputerHistoryEntity = computerHistoryEntity;
                            safeComputerHistoryEntity.IsNew = false;
                            safeComputerHistoryEntity.DateModified = DateTime.Now;
                            break;
                        }
                    }
                }
                else
                {
                    safeComputerHistoryEntity.IsNew = true;
                }
                
                if (!adapter.SaveEntity(safeComputerHistoryEntity, false))
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }
    }
}
