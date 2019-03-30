namespace ASPFinal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;
    using ASPFinal.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ASPFinal.DAL.CarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ASPFinal.DAL.CarContext";
        }

        protected override void Seed(ASPFinal.DAL.CarContext context)
        {
            string password = Crypto.HashPassword("amil0055");
            context.Users.AddOrUpdate(u => u.Email, new User[] {
                    new User { Name = "Amil", Lastname = "Abdullayev", Email = "amil7.abdullayev@gmail.com", PhoneNumber = "0704400500", Password = password }
                });
            context.SaveChanges();

            context.News.AddOrUpdate(n => new { n.Title, n.Content }, new News[] {
                    new News{ Image = "2.jpeg", Title = "Lorem ipsum dolor Title 1", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Qui dicta minus molestiae vel beatae natus eveniet ratione Content 1", CreateDate = new DateTime (2018, 05, 07)},
                    new News{ Image = "2.jpeg", Title = "Lorem ipsum dolor Title 2", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Qui dicta minus molestiae vel beatae natus eveniet ratione Content 2", CreateDate = new DateTime (2016, 05, 07)},
                    new News{ Image = "2.jpeg", Title = "Lorem ipsum dolor Title 3", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Qui dicta minus molestiae vel beatae natus eveniet ratione Content 3", CreateDate = new DateTime (2017, 05, 07)},
                    new News{ Image = "2.jpeg", Title = "Lorem ipsum dolor Title 4", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Qui dicta minus molestiae vel beatae natus eveniet ratione Content 4", CreateDate = new DateTime (2018, 05, 07)},
                    new News{ Image = "2.jpeg", Title = "Lorem ipsum dolor Title 5", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Qui dicta minus molestiae vel beatae natus eveniet ratione Content 5", CreateDate = new DateTime (2014, 05, 07)},
                    new News{ Image = "2.jpeg", Title = "Lorem ipsum dolor Title 6", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Qui dicta minus molestiae vel beatae natus eveniet ratione Content 6", CreateDate = new DateTime (2015, 05, 07)},
                    new News{ Image = "2.jpeg", Title = "Lorem ipsum dolor Title 7", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Qui dicta minus molestiae vel beatae natus eveniet ratione Content 7", CreateDate = new DateTime (2018, 05, 07)}
                });
            context.SaveChanges();

            context.Gearboxes.AddOrUpdate(g => g.Name, new Gearbox[] {
                new Gearbox{ Name = "Mechanic" },
                new Gearbox { Name = "Automatic" }
            });
            context.SaveChanges();

            context.FuelTypes.AddOrUpdate(f => f.Name, new FuelType[] {
                  new FuelType { Name = "Diesel" },
                  new FuelType { Name = "Gasoline" },
                  new FuelType { Name = "Electric" }

            });
            context.SaveChanges();

            context.Markas.AddOrUpdate(m => m.Name, new Marka[] {
                new Marka { Name = "BMW" },
                new Marka { Name = "Mercedes" },
                new Marka { Name = "Alfa-Romeo" },
                new Marka { Name = "Porsche" },
                new Marka { Name = "Lada" }
            });
            context.SaveChanges();

            context.Models.AddOrUpdate(m => m.Name, new Model[] {
                new Model { Name = "M5", MarkaId = 1 },
                new Model { Name = "ML", MarkaId = 2 },
                new Model { Name = "M6", MarkaId = 1 },
                new Model { Name = "GL", MarkaId = 2 },
                new Model { Name = "Priora", MarkaId = 5 },
                new Model { Name = "Cayenne", MarkaId = 4 },
                new Model { Name = "07", MarkaId = 5 },
                new Model { Name = "C-Class", MarkaId = 2 },
                new Model { Name = "X6", MarkaId = 1 },
                new Model { Name = "E-Class", MarkaId = 2 }
            });
            context.SaveChanges();

            context.CarDetails.AddOrUpdate(cd => cd.Model, new CarDetails[] {
                new CarDetails { Image = "featured-2.jpeg", Price = 123000,ModelId = 1, ProductionYear = new DateTime (2015,02,25), EngineCapacity = 5.4, CarMarch = 100000, Color = "Red", ShortContent = "Vurugu yoxdur. Heci masinidi. Icinde icki icilmeyib. Vurugu da yoxdur. Bezkraskadir.", FuelTypeId = 1, GearboxId = 1 },
                new CarDetails { Image = "featured-2.jpeg", Price = 213000,ModelId = 2, ProductionYear = new DateTime (2012,02,25), EngineCapacity = 5.8, CarMarch = 122000, Color = "Black", ShortContent = "Vurugu yoxdur. Heci masinidi. Icinde icki icilmeyib. Vurugu da yoxdur. Bezkraskadir.", FuelTypeId = 2, GearboxId = 1 },
                new CarDetails { Image = "featured-2.jpeg", Price = 343000, ModelId = 3, ProductionYear = new DateTime (2011,02,25), EngineCapacity = 2.4, CarMarch = 126000, Color = "Yellow", ShortContent = "Vurugu yoxdur. Heci masinidi. Icinde icki icilmeyib. Vurugu da yoxdur. Bezkraskadir.", FuelTypeId = 2, GearboxId = 2 },
                new CarDetails { Image = "featured-2.jpeg", Price = 5623000, ModelId = 5, ProductionYear = new DateTime (2017,02,25), EngineCapacity = 3.4, CarMarch = 210000, Color = "White", ShortContent = "Vurugu yoxdur. Heci masinidi. Icinde icki icilmeyib. Vurugu da yoxdur. Bezkraskadir.", FuelTypeId = 3, GearboxId = 2 },
                new CarDetails { Image = "featured-2.jpeg", Price = 156000, ModelId = 4, ProductionYear = new DateTime (2014,02,25), EngineCapacity = 5.5, CarMarch = 100000, Color = "Black", ShortContent = "Vurugu yoxdur. Heci masinidi. Icinde icki icilmeyib. Vurugu da yoxdur. Bezkraskadir.", FuelTypeId = 1, GearboxId = 2 },
                new CarDetails { Image = "featured-2.jpeg", Price = 783000, ModelId = 2, ProductionYear = new DateTime (2005,02,25), EngineCapacity = 4.4, CarMarch = 230000, Color = "Red", ShortContent = "Vurugu yoxdur. Heci masinidi. Icinde icki icilmeyib. Vurugu da yoxdur. Bezkraskadir.", FuelTypeId = 3, GearboxId = 1 },
            });
            context.SaveChanges();

            context.Announcements.AddOrUpdate(a => a.Vip, new Announcements[] {
                new Announcements { Vip = true, CreateDate = new DateTime (2017, 02, 05), UpdateDate = new DateTime (2018, 05, 02), City = "NY", CardDetailsId = 1 },
                new Announcements { Vip = false, CreateDate = new DateTime (2018, 02, 05), UpdateDate = new DateTime (2019, 01, 02), City = "Chicago", CardDetailsId = 2 },
                new Announcements { Vip = true, CreateDate = new DateTime (2015, 02, 05), UpdateDate = new DateTime (2017, 01, 02), City = "Baku", CardDetailsId = 2 },
                new Announcements { Vip = false, CreateDate = new DateTime (2015, 02, 05), UpdateDate = new DateTime (2017, 01, 02), City = "Chicago", CardDetailsId = 3 },
                new Announcements { Vip = true, CreateDate = new DateTime (2018, 02, 05), UpdateDate = new DateTime (2019, 01, 02), City = "Baku", CardDetailsId = 6 },
                new Announcements { Vip = false, CreateDate = new DateTime (2016, 02, 05), UpdateDate = new DateTime (2018, 01, 02), City = "LY", CardDetailsId = 1 },
                new Announcements { Vip = true, CreateDate = new DateTime (2012, 02, 05), UpdateDate = new DateTime (2015, 01, 02), City = "Chicago", CardDetailsId = 3 },
                new Announcements { Vip = false, CreateDate = new DateTime (2014, 02, 05), UpdateDate = new DateTime (2019, 01, 02), City = "LA", CardDetailsId = 4 },
                new Announcements { Vip = true, CreateDate = new DateTime (2014, 02, 05), UpdateDate = new DateTime (2015, 01, 02), City = "Chicago", CardDetailsId = 5 },
                new Announcements { Vip = false, CreateDate = new DateTime (2017, 02, 05), UpdateDate = new DateTime (2018, 01, 02), City = "LA", CardDetailsId = 5 },
                new Announcements { Vip = true, CreateDate = new DateTime (2016, 02, 05), UpdateDate = new DateTime (2017, 01, 02), City = "LA", CardDetailsId = 4 },
                new Announcements { Vip = true, CreateDate = new DateTime (2013, 02, 05), UpdateDate = new DateTime (2014, 01, 02), City = "Chicago", CardDetailsId = 6 }
            });
            context.SaveChanges();
        }
    }
}
