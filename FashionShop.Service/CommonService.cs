using FashionShop.Data.Infrastructure;
using FashionShop.Data.Repositories;
using FashionShop.Model.Models;
using System.Collections.Generic;

namespace FashionShop.Service
{
    public interface ICommonService
    {
        IEnumerable<Slide> GetSlides();
        SystemConfig GetSystemConfig(string code);
    }

    public class CommonService : ICommonService
    {
        ISlideRepository _slideRepository;
        IUnitOfWork _unitOfWork;
        ISystemConfigRepository _systemConfigRepository;

        public CommonService(IUnitOfWork unitOfWork, ISlideRepository slideRepository, ISystemConfigRepository systemConfigRepository)
        {
            _slideRepository = slideRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
        }



        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }

        public SystemConfig GetSystemConfig(string code)
        {
            return _systemConfigRepository.GetSingleByCondition(x => x.Code == code);
        }
    }
}