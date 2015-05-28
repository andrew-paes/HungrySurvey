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
    public class LunchSuggestionService : EntityService<LunchSuggestion>, ILunchSuggestionService
    {
        IUnitOfWork _unitOfWork;
        ILunchSuggestionRepository _lunchSuggestionRepository;

        public LunchSuggestionService(IUnitOfWork unitOfWork, ILunchSuggestionRepository lunchSuggestionRepository)
            : base(unitOfWork, lunchSuggestionRepository)
        {
            _unitOfWork = unitOfWork;
            _lunchSuggestionRepository = lunchSuggestionRepository;
        }


        public LunchSuggestion GetById(int Id)
        {
            return _lunchSuggestionRepository.GetById(Id);
        }
    }
}
