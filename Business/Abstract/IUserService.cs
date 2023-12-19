using DataAccess.Entity;
using DTO.DTOEntity;


namespace Business.Abstract
{
    public interface IUserService:IBaseService<UserDTO,User,UserDTO>
    {
        UserDTO Login(UserDTO model);
    }
}
