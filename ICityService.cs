using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityDetails.Models;

namespace CityDetails.Services.Interface
{
    public interface ICityService
    {
        List<CityDetailModel> FetchCityDetails(int CityId);

        bool SaveCityDetails(CityDetailModel CityDetails);

        bool DeleteCityDetails(int CityId);

    }
}
