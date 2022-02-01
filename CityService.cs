using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityDetails.Models;
using CityDetails.Services.Interface;
using CityDetails.Repositories.Interface;
using CityDetails.Repositories.Implementation;
using System.Data;

namespace CityDetails.Services.Implementation
{
    public class CityService : ICityService
    {
        private ICityRepository cityRepository;
        public CityService() { cityRepository = new CityRepository(); }
        public bool DeleteCityDetails(int CityId)
        {
            if (cityRepository.RemoveCityDetails(CityId))
            {
                return true;
            }
            return false;
        }

        public List<CityDetailModel> FetchCityDetails(int CityId)
        {
            DataSet _dataSet = cityRepository.GetCityDetails(CityId);
            List<CityDetailModel> cityDataList = new List<CityDetailModel>();

            foreach(DataRow dr in _dataSet.Tables[0].Rows)
            {
                CityDetailModel cityModelData = new CityDetailModel();
                cityModelData.CityId = Convert.ToInt16(dr["CityId"].ToString());
                cityModelData.Name = dr["Name"].ToString();
                cityModelData.State = dr["Region"].ToString();
                cityModelData.Country = dr["Country"].ToString();
                cityModelData.TouristRating = Convert.ToInt16(dr["TouristRating"].ToString());
                cityModelData.EstablishedDate = Convert.ToDateTime(dr["EstablishedDate"].ToString());
                cityModelData.EstimatedPopulation = Convert.ToDouble(dr["EstimatedPopulation"].ToString());

                cityDataList.Add(cityModelData);
            }

            return cityDataList;
        }

        public bool SaveCityDetails(CityDetailModel CityDetails)
        {
            if (cityRepository.SaveCityDetails(CityDetails))
            {
                return true;
            }
            return false;
        }
    }
}
