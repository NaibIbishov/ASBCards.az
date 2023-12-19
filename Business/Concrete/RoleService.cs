using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.DTOEntity;


namespace Business.Concrete
{
    public class RoleService:BaseService<RoleDTO,Role,RoleDTO>,IRoleService
    {
        public RoleService(IMapper mapper,AppDbContext appDbContext) : base(mapper, appDbContext) 
        {
            
        }
    }
}
