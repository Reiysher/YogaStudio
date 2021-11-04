using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Mentors.Queries.GetMentorsList
{
    public class MentorsListVm
    {
        public IList<MentorLookupDto> Mentors { get; set; }
    }
}
