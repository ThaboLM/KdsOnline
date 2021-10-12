using System;
using System.Collections.Generic;
using System.Text;

namespace KdsOnline.Application.Features.PersonalDetails.Queries
{
    public class GetAllPersonalDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string Nationality { get; set; }
        public virtual long ContactId { get; set; }
    }
}
