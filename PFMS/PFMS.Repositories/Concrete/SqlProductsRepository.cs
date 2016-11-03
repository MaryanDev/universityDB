using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;

namespace PFMS.Repositories.Concrete
{
    public class SqlProductsRepository : BaseRepository, IProductsRepository
    {
        public SqlProductsRepository(PintingFactoryDBEntities context) : base(context)
        {

        }
        public void Delete(Product entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;

        }

        public IEnumerable<Product> Get(Func<Product, bool> criteria = null)
        {
            var result = (criteria == null ? context.Products : context.Products.Where(criteria)).Select(p => new Product
            {
                Id = p.Id,
                Title = p.Title,
                Cost = p.Cost
            });
            return result;
        }

        public int GetCountOfRecords(Func<Product, bool> criteria = null)
        {
            return criteria == null ? context.Products.Count() : context.Products.Where(criteria).Count();

        }

        public Product GetSingle(Func<Product, bool> criteria)
        {
            var resultEntity = criteria == null ? context.Products.FirstOrDefault() : context.Products.Where(criteria).FirstOrDefault();
            return resultEntity;
        }

        public Product Insert(Product entity)
        {
            context.Set<Product>().Add(entity);
            return entity;
        }

        public Product Update(Product entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }
    }
}
