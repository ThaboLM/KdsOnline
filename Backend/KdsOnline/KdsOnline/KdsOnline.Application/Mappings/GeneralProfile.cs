using AutoMapper;
using KdsOnline.Application.Features.Addresses.Commands;
using KdsOnline.Application.Features.Addresses.Queries;
using KdsOnline.Application.Features.Contacts.Commands;
using KdsOnline.Application.Features.Contacts.Queries;
using KdsOnline.Application.Features.PersonalDetails;
using KdsOnline.Application.Features.PersonalDetails.Queries;
using KdsOnline.Application.Features.Products.Commands.CreateProduct;
using KdsOnline.Application.Features.Products.Queries.GetAllProducts;
using KdsOnline.Domain.Entities;

namespace KdsOnline.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<PersonalDetail, GetAllPersonalDetailsViewModel>().ReverseMap();
            CreateMap<CreatePersonalDetailCommand, PersonalDetail>();
            CreateMap<GetAllPersonalDetailsQuery, GetAllPersonalDetailsParameters>();

            CreateMap<Contact, GetAllContactsViewModel>().ReverseMap();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<GetAllContactsQuery, GetAllContactsParameter>();

            CreateMap<Address, GetAllAddressViewModel>().ReverseMap();
            CreateMap<CreateAddressCommand, Address>();
            CreateMap<GetAllAddressesQuery, GetAllContactsParameter>();
        }
    }
}
