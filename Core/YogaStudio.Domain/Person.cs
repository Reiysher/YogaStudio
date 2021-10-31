using System;

namespace YogaStudio.Domain
{
    public abstract class Person : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
