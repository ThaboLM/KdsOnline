using System;
using System.Collections.Generic;
using System.Text;

namespace KdsOnline.Application.Features.Contacts.Queries
{
    public class GetAllContactsViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
