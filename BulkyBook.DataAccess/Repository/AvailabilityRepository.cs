using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class AvailabilityRepository : Repository<Availability>, IAvailabilityRepository
    {
        private ApplicationDbContext _db;

        public AvailabilityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Availability obj)
        {
            _db.AvailabilityTypes.Update(obj);
        }
    }
}
