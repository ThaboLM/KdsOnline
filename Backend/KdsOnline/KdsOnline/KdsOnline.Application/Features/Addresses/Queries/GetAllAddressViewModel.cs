namespace KdsOnline.Application.Features.Addresses.Queries
{
    public class GetAllAddressViewModel
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public bool IsComplex { get; set; }
        public string ComplexName { get; set; }
        public int UnitNumber { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }
    }
}
