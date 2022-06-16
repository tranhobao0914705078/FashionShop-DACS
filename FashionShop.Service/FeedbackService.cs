using FashionShop.Data.Infrastructure;
using FashionShop.Data.Repositories;
using FashionShop.Model.Models;

namespace FashionShop.Service
{
    public interface IFeedbackService
    {
        FeedBack Create(FeedBack feedBack);

        void Save();
    }

    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWork = unitOfWork;
        }

        public FeedBack Create(FeedBack feedBack)
        {
            return _feedbackRepository.Add(feedBack);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}