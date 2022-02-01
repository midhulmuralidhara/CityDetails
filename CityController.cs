using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityDetails.Models;
using CityDetails.Services.Interface;
using System.Text.Json;

namespace CityDetails.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService ICityServiceInstance;
        public  CityController(ICityService _ICityService)
        {
            ICityServiceInstance = _ICityService;
        }

        [HttpGet("GetCityData")]
        public IActionResult GetCityData(int CityId)
        {
            var CityDetails = ICityServiceInstance.FetchCityDetails(CityId);
            return Ok(CityDetails);
        }

        [HttpGet("AddUpdateCityData")]
        public IActionResult AddUpdateCityData(string CityDetailData)
        {
            CityDetailModel serializedData = JsonSerializer.Deserialize<CityDetailModel>(CityDetailData);
            bool result = ICityServiceInstance.SaveCityDetails(serializedData);

            return Ok(result);
        }

        

        [HttpGet("DeleteCityData")]
        public IActionResult DeleteCityData(int CityId)
        {
            bool result = ICityServiceInstance.DeleteCityDetails(CityId);

            return Ok(result);
        }

    }
}