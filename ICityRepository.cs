using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CityDetails.Models;

namespace CityDetails.Repositories.Interface
{
    interface ICityRepository
    {
        DataSet GetCityDetails(int CityId);
        bool SaveCityDetails(CityDetailModel CityData);

        bool RemoveCityDetails(int  CityId);
    }
}
