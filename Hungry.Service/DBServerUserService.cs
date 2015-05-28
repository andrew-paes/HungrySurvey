using Hungry.Model;
using Hungry.Repository.Generics;
using Hungry.Repository.Interfaces;
using Hungry.Service.Commom;
using Hungry.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Service
{
    public class DBServerUserService : EntityService<DBServerUser>, IDBServerUserService
    {
        IUnitOfWork _unitOfWork;
        IDBServerUserRepository _dbServerUserRepository;

        public DBServerUserService(IUnitOfWork unitOfWork, IDBServerUserRepository dbServerUserRepository)
            : base(unitOfWork, dbServerUserRepository)
        {
            _unitOfWork = unitOfWork;
            _dbServerUserRepository = dbServerUserRepository;
        }


        public DBServerUser GetById(int Id)
        {
            return _dbServerUserRepository.GetById(Id);
        }
    }
}
