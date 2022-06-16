using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionShop.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { set; get; }
        [MaxLength(250, ErrorMessage ="Tên vượt quá ký tự cho phép!!!")]
        [Required]
        public string Name { set; get; }
        [MaxLength(250, ErrorMessage = "Email vượt quá ký tự cho phép!!!")]
        public string Email { set; get; }
        [MaxLength(250, ErrorMessage = "Tin nhắn vượt quá ký tự cho phép!!!")]
        public string Message { set; get; }
        public DateTime CreatedDate { set; get; }
        [Required(ErrorMessage ="Vui lòng nhập trạng thái!!!")]
        public bool Status { set; get; }

        public ContactDetailViewModel ContactDetail { set; get; }
    }
}