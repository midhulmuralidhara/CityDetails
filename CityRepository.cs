using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityDetails.Models;
using CityDetails.Repositories.Interface;
using CityDetails.DataAccess;
using CityDetails.Constants;
using System.Data;

namespace CityDetails.Repositories.Implementation
{
    public class CityRepository: ICityRepository
    {
        private SQLDbHelper sqlDBHelper;
        public CityRepository() 
        {
            sqlDBHelper = new SQLDbHelper(Common.ConnectionString);
        }

        public DataSet GetCityDetails(int CityId)
        {
            var paramsdata = GenerateParams("@CityId", CityId);
            var paramsList = new List<SQLParams>();
            paramsList.Add(paramsdata);

            return sqlDBHelper.ManageCityData(paramsList, "Get");

        }

        public bool RemoveCityDetails(int CityId)
        {
            var paramsdata = GenerateParams("@CityId", CityId);
            var paramsList = new List<SQLParams>();
            paramsList.Add(paramsdata);

            sqlDBHelper.ManageCityData(paramsList, "Delete");
            return true;
        }

        public bool SaveCityDetails(CityDetailModel CityData)
        {
            sqlDBHelper.ManageCityData(GenerateSaveDataParams(CityData), "SaveUpdate");
            return true;
        }

        private SQLParams GenerateParams(string key, dynamic value)
        {
            SQLParams sqlParams = new SQLParams();
            sqlParams.Key = key;
            sqlParams.DataType = System.Data.SqlDbType.Int;
            sqlParams.Value = value;

            return sqlParams;
        }

        private List<SQLParams> GenerateSaveDataParams(CityDetailModel CityData)
        {
            List<SQLParams> sqlParamsList = new List<SQLParams>();
            
                        
            sqlParamsList.Add(GenerateParams("@cityid", CityData.CityId));
            sqlParamsList.Add(GenerateParams("@name", CityData.Name));
            sqlParamsList.Add(GenerateParams("@region", CityData.State));
            sqlParamsList.Add(GenerateParams("@country", CityData.Country));
            sqlParamsList.Add(GenerateParams("@touristrating", CityData.TouristRating));
            sqlParamsList.Add(GenerateParams("@establisheddate", CityData.EstablishedDate));
            sqlParamsList.Add(GenerateParams("@estimatedpopulation", CityData.EstimatedPopulation));



            return sqlParamsList;
        }
    }
}
