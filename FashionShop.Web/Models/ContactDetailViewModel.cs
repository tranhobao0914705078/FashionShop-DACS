using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionShop.Web.Models
{
    public class ContactDetailViewModel
    {
        public int ID { set; get; }


        [Required(ErrorMessage = "Tên không được trống!!!")]
        public string Name { set; get; }
        [StringLength(50, ErrorMessage = "Số điện thoại vượt quá ký tự cho phép!!!")]
        public string Phone { set; get; }
        [StringLength(250, ErrorMessage = "Email vượt quá ký tự cho phép!!!")]
        public string Email { set; get; }
        [StringLength(250, ErrorMessage = "Website vượt quá ký tự cho phép!!!")]
        public string Website { set; get; }
        [StringLength(250, ErrorMessage = "Địa chỉ vượt quá ký tự cho phép!!!")]
        public string Adderess { set; get; }
        public string Other { set; get; }
        public bool Status { set; get; }
    }
}