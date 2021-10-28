using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Domain
{
    public class YogaClass
    {
        // class id
        public Guid Id { get; set; }
        // mentor(user) id
        public Guid MentorId { get; set; }
        // list of clients(users) id
        public IEnumerable<Guid> UsersIds { get; set; }
        // class date
        
        // class status

        // class type

        // class description
    }
}
