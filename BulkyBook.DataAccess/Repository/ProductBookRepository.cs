using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductBookRepository : Repository<ProductBook>, IProductBookRepository
    {
        private ApplicationDbContext _db;

        public ProductBookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductBook obj)
        {
            _db.ProductBooks.Update(obj);
        }

    }
}
