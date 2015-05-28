using Hungry.Model;
using Hungry.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Repository.Interfaces
{
    public interface ILunchSuggestionRepository : IGenericRepository<LunchSuggestion>
    {
        LunchSuggestion GetById(int id);
    }
}