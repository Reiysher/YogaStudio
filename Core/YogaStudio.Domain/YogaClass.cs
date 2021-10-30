using System;
using System.Collections.Generic;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Domain
{
    public class YogaClass
    {
        // class id
        public Guid Id { get; set; }
        // mentor(user) id
        public Guid MentorId { get; set; }
        // list of clients(users), who signed up for class
        public IEnumerable<Guid> SignedUpUsers { get; set; }
        // list of clients(users) who attended the class
        public IEnumerable<Guid> AttendedUsers { get; set; }
        // class date
        public DateTime Date { get; set; }
        // class status (Active/Canceled)
        public YogaClassStatus Status { get; set; }
        // class type (morning, normal, online)
        public YogaClassType Type { get; set; }
        // class description
        public string Description { get; set; }
        // Minimum count of users
        public int MinUsers { get; set; }
        // Maximum count of users
        public int MaxUsers { get; set; }
    }
}
