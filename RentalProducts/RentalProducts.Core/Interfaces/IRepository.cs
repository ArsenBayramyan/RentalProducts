using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> List { get; }
        void Save(T entity);
        bool Delete(int id);
    }
}
