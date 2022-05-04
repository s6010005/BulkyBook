using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }
        IProductBookRepository ProductBook { get; }
        IAvailabilityRepository Availability { get; }
        ICompanyRepository Company { get; }

        void Save();
    }
}
