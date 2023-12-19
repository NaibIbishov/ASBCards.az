using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.DTOEntity;
using Helper.Constants;
using Helper.CookieCrypto;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
        public UserService(IMapper mapper, AppDbContext appDbContext) : base(mapper, appDbContext)
        {

        }

        public UserDTO Login(UserDTO model)
        {
            var res = _appDbContext.Users
            .Where(x => x.UserName.ToLower() == model.UserName.ToLower())
             .Include(u => u.Role);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();

                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Şifrə yalnışdır!");
                }
            }
            else
            {
                throw new Exception("Hesab mövcud deyil");
            }
        }

        public override UserDTO Insert(UserDTO dto)
        {
            var res = _appDbContext.Users.Where(x => x.UserName == dto.UserName);
            var resmail = _appDbContext.Users.Where(x => x.Email == dto.Email);

            var role = _appDbContext.Roles.Where(x => x.Name == RoleKeywords.UserRole)?.First();
            dto.RoleId = role.ID;

            if (res.Any())
            {
                throw new Exception("Bu istifadəçi adı mövcuddur!");
            }
            if (resmail.Any())
            {
                throw new Exception("Bu mail mövcuddur!");
            }


            dto.Salt = Crypto.GenerateSalt();
            dto.PasswordHash = Crypto.GenerateSHA256Hash(dto.Password, dto.Salt);

            return base.Insert(dto);
        }
    }
}