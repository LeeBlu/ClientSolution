using AutoMapper;
using ClientSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientSolution.Web.Enums;

namespace ClientSolution.Web.ViewModels
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<PersonVM, Person>()
            .ForMember(dest => dest.GenderId,
                       opt => opt.MapFrom(src => (int)src.gender));
            CreateMap<Person, PersonVM>()
            .ForMember(dest=>dest.gender,
                       opt => opt.MapFrom(src => (Gender)src.GenderId));
            CreateMap<AddressVM, Address>()
                .ForMember(dest => dest.AddressTypeId,
                       opt => opt.MapFrom(src => (int)src.addressType))
                .ForMember(dest => dest.ProvinceId,
                       opt => opt.MapFrom(src => (int)src.province));
                       
            CreateMap<Address, AddressVM>()
               .ForMember(dest => dest.province,
                       opt => opt.MapFrom(src => (Province)src.ProvinceId))
               .ForMember(dest => dest.addressType,
                       opt => opt.MapFrom(src => (AddressType)src.AddressTypeId));
        }
    }
}
