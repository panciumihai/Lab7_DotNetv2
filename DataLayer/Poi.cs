using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Poi
    {
        public Guid PoiId { get; set; }
        [MinLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CityId { get; set; }

        public Poi(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}