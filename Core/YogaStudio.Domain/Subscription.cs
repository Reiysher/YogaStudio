using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Domain
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Guid UserdId { get; set; }
        public int NumberOfYogaClasses { get; set; }
        public SubscriptionStatus Status { get; set; }
        public YogaClassType Type { get; set; }
        public DateTime SubscriptionPeriod { get; set; }

    }
}
