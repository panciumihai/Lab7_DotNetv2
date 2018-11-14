using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace BusinessLayer
{
    public interface ICityRepository
    {
        void Create(City city);
        void Edit(Guid id, City city);
        void Delete(Guid guid);
        City Get(Guid guid);
        IReadOnlyCollection<City> GetAll();
    }
}
