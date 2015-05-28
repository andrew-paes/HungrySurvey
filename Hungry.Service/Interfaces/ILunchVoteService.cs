using Hungry.Model;
using Hungry.Service.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Service.Interfaces
{
    public interface ILunchVoteService : IEntityService<LunchVote>
    {
        LunchVote GetById(int Id);
    }
}
