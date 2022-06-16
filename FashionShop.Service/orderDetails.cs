using FashionShop.Data.Repositories;
using FashionShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Service
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetails> GetAll();
    }

    public class orderDetails : IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;

        public orderDetails(IOrderDetailRepository orderDetailRepository)
        {
            this._orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            return _orderDetailRepository.GetAll();
        }
    }
}
