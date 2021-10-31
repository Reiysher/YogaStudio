﻿using System;
using System.Collections.Generic;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Domain
{
    public class YogaClass : BaseEntity<Guid>
    {
        public Guid MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int MinClients { get; set; }
        public int MaxClients { get; set; }
        public YogaClassType Type { get; set; }
        public YogaClassStatus Status { get; set; }
    }
}
