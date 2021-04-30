using FetchingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FetchingAPI.Controllers
{
    [Route("api/fetch")]
    [ApiController]
    public class fetchController : ControllerBase
    {
        [HttpGet]
        [Route("data")]

        public  IActionResult GetData()
        {
            try 
            {
                var client = new WebClient();
                var json = client.DownloadString("https://api.coindesk.com/v1/bpi/currentprice.json");
                var result = JsonConvert.DeserializeObject<Coindesk>(json);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message + " " + e.StackTrace);
            }
            

        }



    }
}
