﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { set; get; }
        public IEnumerable<ProductViewModel> LastesProducts { set; get; }
        public IEnumerable<ProductViewModel> TopSaleProducts { set; get; }

        public string Title { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}