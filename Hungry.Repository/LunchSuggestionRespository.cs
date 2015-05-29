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
    public class LunchSuggestionRespository : GenericRepository<LunchSuggestion>, ILunchSuggestionRepository
    {
        public LunchSuggestionRespository(DbContext context)
            : base(context)
        {

        }

        public LunchSuggestion GetById(int id)
        {
            return _dbset.Include(x => x.LunchVote).Where(x => x.LunchSuggestionId == id).FirstOrDefault();
        }
    }
}