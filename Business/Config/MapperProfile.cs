using AutoMapper;
using DataAccess.Entity;
using DTO.DTOEntity;


namespace Business.Config
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<RoleDTO, Role>();
            CreateMap<Role,RoleDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(c => c.Role.Name));
         
            

            CreateMap<OrderCardDTO, OrderCard>();
            CreateMap<OrderCard, OrderCardDTO>();

                
        }
    }
}
