using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Mentors.Commands.UpdateMentor
{
    public class UpdateMentorCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<YogaClass> Classes { get; set; }
    }
}
