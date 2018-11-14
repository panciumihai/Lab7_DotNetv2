using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class City
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
        [MinLength(50)]
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
