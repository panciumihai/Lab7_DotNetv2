using System;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class PoiRepository
    {
        private readonly PoiContext _context;

        public PoiRepository(PoiContext context)
        {
            _context = context;
        }

        public void Create(Poi city)
        {
            city.PoiId = new Guid();
            _context.Pois.Add(city);
            _context.SaveChanges();
        }

        public void Edit(Guid id, Poi city)
        {
            _context.Pois.Update(city);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            var result = _context.Pois.FirstOrDefault(c => c.PoiId == guid);
            if (result != null)
            {
                _context.Pois.Remove(result);
                _context.SaveChanges();
            }
        }

        public Poi Get(Guid guid)
        {
            return _context.Pois.FirstOrDefault(c => c.PoiId == guid);
        }

        public IReadOnlyCollection<Poi> GetAll()
        {
            return _context.Pois.ToList();
        }
    }
}