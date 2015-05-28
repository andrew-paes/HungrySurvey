using Hungry.Model;
using Hungry.Repository.Generics;
using Hungry.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Repository
{
    public class DBServerUserRespository : GenericRepository<DBServerUser>, IDBServerUserRepository
    {
        public DBServerUserRespository(DbContext context)
            : base(context)
        {

        }

        public DBServerUser GetById(int id)
        {
            return _dbset.Include(x => x.LunchVote).Where(x => x.Id == id).FirstOrDefault();
        }

        public override IEnumerable<DBServerUser> GetAll()
        {
            return _entities.Set<DBServerUser>().Include(x => x.LunchVote).AsEnumerable();
        }
    }
}
