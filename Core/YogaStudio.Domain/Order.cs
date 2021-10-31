using System;

namespace YogaStudio.Domain
{
    public class Order : BaseEntity<int>
    {
        public Guid YogaClassId { get; set; }
        public YogaClass YogaClass { get; set; }

        public Guid SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
