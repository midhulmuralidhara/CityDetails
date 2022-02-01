using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CityDetails.Constants;
using CityDetails.Models;

namespace CityDetails.DataAccess
{
    public class SQLDbHelper
    {
        private SqlConnection SQlconnectionInstance;
        private SqlCommand SQLCommandObject;
        
        public SQLDbHelper(string connectionstring)
        {
            SQlconnectionInstance = new SqlConnection(connectionstring);
        }

        public DataSet ManageCityData(List<SQLParams> DataParams, string Operation)
        {
            InitializeSQLCommand();
            SQlconnectionInstance.Open();

            SQLCommandObject.Connection = SQlconnectionInstance;
            SQLCommandObject.CommandType = CommandType.StoredProcedure;
            DataSet cityData = new DataSet();

            foreach(var dataitem in DataParams)
            {
                SQLCommandObject.Parameters.Add(dataitem.Key, dataitem.DataType);
                SQLCommandObject.Parameters[dataitem.Key].Value = dataitem.Value;
            }

            SQLCommandObject.CommandText = Operation == "Get"?StoredProcedures.GetCityDetails:Operation == "SaveUpdate"? StoredProcedures.SaveCityDetails: StoredProcedures.DeleteCityDetails;

            try
            {
                if(Operation == "Get")
                {
                    var SQlCityDataAdapter = GetDataAdapter();
                    SQlCityDataAdapter.Fill(cityData);
                }
                else
                {
                    SQLCommandObject.ExecuteNonQuery();
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQlconnectionInstance.Close();
                SQLCommandObject.Dispose();
                SQlconnectionInstance.Dispose();
            }

            return cityData;
        }

        private void InitializeSQLCommand()
        {
            SQLCommandObject = new SqlCommand();
        }

        private SqlDataAdapter GetDataAdapter()
        {
            return new SqlDataAdapter(SQLCommandObject);
        }
    }

    
}
