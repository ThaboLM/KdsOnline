using KdsOnline.Domain.Common;
using System;

namespace KdsOnline.Domain.Entities
{
    public class PersonalDetail : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string Nationality { get; set; }
        public long? ContactId { get; set; }
    }
}
