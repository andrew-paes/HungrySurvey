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
    public class LunchVoteRepository : GenericRepository<LunchVote>, ILunchVoteRepository
    {
        public LunchVoteRepository(DbContext context)
            : base(context)
        {

        }

        public LunchVote GetById(int id)
        {
            return _dbset.Include(x => x.LunchSuggestion).Where(x => x.LunchVoteId == id).FirstOrDefault();
        }
    }
}