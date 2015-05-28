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
    public class LunchVoteService : EntityService<LunchVote>, ILunchVoteService
    {
        IUnitOfWork _unitOfWork;
        ILunchVoteRepository _lunchVoteRepository;

        public LunchVoteService(IUnitOfWork unitOfWork, ILunchVoteRepository lunchVoteRepository)
            : base(unitOfWork, lunchVoteRepository)
        {
            _unitOfWork = unitOfWork;
            _lunchVoteRepository = lunchVoteRepository;
        }


        public LunchVote GetById(int Id)
        {
            return _lunchVoteRepository.GetById(Id);
        }
    }
}
