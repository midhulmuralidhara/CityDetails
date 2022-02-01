using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityDetails.Models
{
    public class CityDetailModel
    {
        public int CityId { get; set; } = 0;

        public string Name { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int TouristRating { get; set; }

        public DateTime EstablishedDate { get; set; }

        public double EstimatedPopulation { get; set; }
    }
}
