using AutoMapper;
using Nxm.Conan.Users.Core.Entities.V1;
using Nxm.Conan.Users.Application.Requests;
using Nxm.Conan.Users.Application.Responses;

namespace Nxm.Conan.Users.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            // From domain to reponse   


            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, CreateUserRequest>().ReverseMap();


            CreateMap<User, UserResponse>();








            // From request to domain

     
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();









        }
    }
}
