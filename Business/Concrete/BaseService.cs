using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;


namespace Business.Concrete
{
    public class BaseService<RqDTO, TEntity, RsDTO>
        : IBaseService<RqDTO, TEntity, RsDTO> where TEntity : class
    {
        protected readonly IMapper _mapper;
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }

        public virtual void Delete(int id)
        {
            var ent = _dbSet.Find(id);
            _dbSet.Remove(ent);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<RsDTO> GetAll()
        {
            var ent = _dbSet.ToList();
            var rsdto = _mapper.Map<IEnumerable<RsDTO>>(ent);
            return rsdto;
        }

        public RsDTO GetById(int id)
        {
            var ent = _dbSet.Find(id);
            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public virtual RsDTO Insert(RqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);
            _dbSet.Add(ent);
            _appDbContext.SaveChanges();

            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public void Update(RqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);

            _dbSet.Update(ent);
            _appDbContext.SaveChanges();
        }

        
    }
}
