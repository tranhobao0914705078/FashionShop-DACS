namespace FashionShop.Data.Migrations
{
    using FashionShop.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FashionShop.Data.FashionShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FashionShop.Data.FashionShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            //  This method will be called after migrating to the latest version.
            CreatePage(context);
            CreateContactDeatils(context);
            CreateConfigTitle(context);
        }
        private void CreateConfigTitle(FashionShopDbContext context)
        {
            if(!context.SystemConfigs.Any(x => x.Code == "HomeTitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang Chủ FASHION SHOP",

                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang Chủ FASHION SHOP",

                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang Chủ FASHION SHOP",

                });
            }
        }
        private void CreateUser(FashionShopDbContext context)
        {
             var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new FashionShopDbContext()));

             var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new FashionShopDbContext()));

             var user = new ApplicationUser()
             {
                 UserName = "fashion",
                 Email = "fashionshop@gmail.com",
                 EmailConfirmed = true,
                 BirthDay = DateTime.Now,
                 FullName = "Fashion Shop"
             };
             manager.Create(user, "123654$");

             if (!roleManager.Roles.Any())
             {
                 roleManager.Create(new IdentityRole { Name = "Admin" });
                 roleManager.Create(new IdentityRole { Name = "User" });
             }

             var adminUser = manager.FindByEmail("fashionshop@gmail.com");
             manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(FashionShop.Data.FashionShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="TOPS",Alias="tops",Status=true },
                 new ProductCategory() { Name="BOTTOM",Alias="bottom",Status=true },
                  new ProductCategory() { Name="ACCESSORIES",Alias="accessories",Status=true },
                   new ProductCategory() { Name="BAGS",Alias="bags",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateSlide(FashionShopDbContext context)
        {
            if(context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {Name = "Slide 1", 
                        DisplayOder = 1, 
                        Status=true, Url="#", 
                        Image="/Assets/client/images/drew-house-slide.jpg",
                        Content=@"<h2>FLAT 20% 0FF</h2>
                                <label>Áo Hoodie Drew House Mascot Cream</b></label>
                                <p>6.890.000₫</ p >
                                < span class=""on-get"">GET NOW</span>",},

                    new Slide() {Name = "Slide 2", 
                        DisplayOder = 2, 
                        Status=true, Url="#", 
                        Image="/Assets/client/images/drew-house-slide2.jpg",
                        Content=@"<h2>FLAT 20% 0FF</h2>
                                <label>Áo Hoodie Drew House Mascot Deconstructed Off White DH-CABI1PHOW</b></label>
                                <p>5.090.000₫</ p >
                                < span class=""on-get"">GET NOW</span>",}
                    //new Slide() {Name = "Slide 1", DisplayOder = 1, Status=true, Url="#", Image="/Assets/client/images/drew-house-slide3.jpg"}
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePage(FashionShopDbContext context)
        {
            if(context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Giới thiệu",
                        Alias = "gioi-thieu",
                        Content = @"Fashion Shop thành lập năm 2022 hoạt động như một nhà bán lẻ giày dép, quần áo DREW HOUSE chính hãng. Công ty phục vụ khách 
                                hàng qua hai nền 
                                tảng: Cửa hàng vật lý tại TP. Hồ Chí Minh và website bán hàng fashionshop.vn 
                                Fashion Shop hoạt động trên tiêu chí vì khách hàng, luôn cố gắng mang 
                                đến nhiều sản phẩm đa dạng về thương hiệu, kiểu dáng và màu sắc để phù hợp cá tính tất cả khách hàng. Sneaker Daily cam kết 
                                luôn đưa đến tay người dùng những sản phẩm chính hãng, tôn trọng khách hàng và công sức của nhà sản xuất, nhà sáng tạo đã dành 
                                thời gian để tạo ra các sản phẩm chất lượng.
                                Fashion Shop cung cấp những gì?
                                Hiện tại, Fashion Shop chuyên cung cấp đa dạng những sản phẩm 
                                thời trang bao gồm: Giày dép, quần áo, phụ kiện thời trang trong 
                                đó mặt hàng chủ yếu là Sneaker. Tất cả đều là những mẫu mã mới nhất đến từ những thương hiệu hàng đầu như Nike, adidas, PUMA, 
                                MLB, Jordan, Drew House, ADLV,… và rất nhiều những sản phẩm đặc biệt không được phân phối ở bất cứ đơn vị nào khác trong lãnh 
                                thổ Việt Nam.",
                        Status = true
                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }

        private void CreateContactDeatils(FashionShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new FashionShop.Model.Models.ContactDetail()
                    {
                        Name = "Fashion Shop",
                        Adderess = "10/80C XL Hà Nội, Phường Tân Phú, Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam",
                        Email = "fashionshop@gmail.com",
                        Phone = "+84 1234 56789",
                        Website = "http://fashionshop.com.vn",
                        Other = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }
    }
}
