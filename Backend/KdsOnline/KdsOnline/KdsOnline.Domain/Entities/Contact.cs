using KdsOnline.Domain.Common;

namespace KdsOnline.Domain.Entities
{
    public class Contact : AuditableBaseEntity
    {
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
