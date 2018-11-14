using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace BusinessLayer
{
    class CityRepository
    {
        private readonly CityContext _context;

        public CityRepository(CityContext context)
        {
            _context = context;
        }

        public void Create(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void Edit(Guid id, City city)
        {
            var city1 = _context.Cities.Find(id);
            city1 = city;
            _context.Cities.Update(city1);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            var result = _context.Cities.FirstOrDefault(c => c.CityId == guid);
            if (result != null)
            {
                _context.Cities.Remove(result);
                _context.SaveChanges();
            }
        }

        public City Get(Guid guid)
        {
            return _context.Cities.Find(guid);
        }

        public IReadOnlyCollection<City> GetAll()
        {
            return _context.Cities.ToList();
        }
    }
}
