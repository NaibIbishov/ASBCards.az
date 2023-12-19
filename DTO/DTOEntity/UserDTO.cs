using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DTO.DTOEntity
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string? Image { get; set; }
        public string? ImageURL { get; set; }

        public string? CompanyName { get; set; }
        public string Company { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Info { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }
        public string? Password { get; set; }
        public string? RoleName { get; set; }
        public int RoleId { get; set; }
        public RoleDTO RoleDTO { get; set; }

        public DateTime Create { get; set; }
        public DateTime Update { get; set; }


        public IEnumerable<OrderCardDTO> OrderCardDTOs { get; set; }
    }
}
