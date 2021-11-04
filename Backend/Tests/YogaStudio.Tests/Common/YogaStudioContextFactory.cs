using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;
using YogaStudio.Persistence;

namespace YogaStudio.Tests.Common
{
    public class YogaStudioContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid ItemIdForDelete = Guid.NewGuid();
        public static Guid ItemIdForUpdate = Guid.NewGuid();

        public static YogaStudioDbContext Create()
        {
            var options = new DbContextOptionsBuilder<YogaStudioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new YogaStudioDbContext(options);
            context.Database.EnsureCreated();

            context.Clients.AddRange(
                new Client
                {
                    Id = UserAId,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    PhoneNumber = "PhoneNumber1",
                    Subscriptions = new List<Subscription>()
                },

                new Client
                {
                    Id = UserBId,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    PhoneNumber = "PhoneNumber2",
                    Subscriptions = new List<Subscription>()
                });

            context.Mentors.AddRange(
                new Mentor
                {
                    Id = UserAId,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    PhoneNumber = "PhoneNumber1",
                    Classes = new List<YogaClass>()
                },

                new Mentor
                {
                    Id = UserBId,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    PhoneNumber = "PhoneNumber2",
                    Classes = new List<YogaClass>()
                });

            context.Classes.AddRange(
                new YogaClass
                {
                    Id = ItemIdForDelete,
                    MentorId = UserAId,
                    Subscriptions = new List<Subscription>(),
                    Date = DateTime.Now,
                    Title = "Title1",
                    Description = "Description1",
                    MinClients = 3,
                    MaxClients = 12,
                    Type = YogaClassType.Online,
                    Status = YogaClassStatus.Planned
                },
                new YogaClass
                {
                    Id = ItemIdForUpdate,
                    MentorId = UserBId,
                    Subscriptions = new List<Subscription>(),
                    Date = DateTime.Now,
                    Title = "Title2",
                    Description = "Description2",
                    MinClients = 3,
                    MaxClients = 12,
                    Type = YogaClassType.Offline,
                    Status = YogaClassStatus.Finished
                });

            context.Subscriptions.AddRange(
                new Subscription
                {
                    Id = ItemIdForDelete,
                    ClientId = UserAId,
                    Classes = new List<YogaClass>(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    NumberOfClasses = 20,
                    Type = SubscriptionType.Online,
                    Status = SubscriptionStatus.Active
                },
                new Subscription
                {
                    Id = ItemIdForUpdate,
                    ClientId = UserBId,
                    Classes = new List<YogaClass>(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    NumberOfClasses = 0,
                    Type = SubscriptionType.Offline,
                    Status = SubscriptionStatus.Expired
                });

            context.SaveChanges();
            return context;
        }

        public static void Destroy(YogaStudioDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
