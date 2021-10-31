using System;
using System.Collections.Generic;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Domain
{
    public class Subscription : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfClasses { get; set; }
        public SubscriptionType Type { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}
