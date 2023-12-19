using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.DTOEntity;


namespace Business.Concrete
{
    public class OrderCardService : BaseService<OrderCardDTO, OrderCard, OrderCardDTO>, IOrderCardService
    {
        public OrderCardService(IMapper mapper, AppDbContext appDbContext) : base(mapper, appDbContext)
        {
        }
    }
}
