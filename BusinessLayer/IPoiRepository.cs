using System;
using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer
{
    public interface IPoiRepository
    {
        void Create(Poi city);
        void Edit(Guid id, Poi city);
        void Delete(Guid guid);
        Poi Get(Guid guid);
        IReadOnlyCollection<Poi> GetAll();
    }
}
