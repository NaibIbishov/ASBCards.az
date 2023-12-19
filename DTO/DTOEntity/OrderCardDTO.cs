using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class OrderCardDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Seriya { get; set; }
        public string SeriyaNo { get; set; }
        public string VerilmeYeri { get; set; }
        public string Verilmetarixi { get; set; }
        public string Fincode { get; set; }
        public string TelNumber { get; set; }
        public string Dogumtarixi { get; set; }
        public string DogumYeri { get; set; }
        public string FatikiUnvan { get; set; }
        public string MotherName { get; set; }
        public string MotherSurname { get; set; }
        public string CarNo { get; set; }
        public string Company { get; set; }
        public string Status { get; set; }

        public string FillialKodu { get; set; }
        public string HesabNo { get; set; }
        public string SubHesab { get; set; }

        public int UserId { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
