using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;
using ApiControllers.Infrastructure.CustomFormatters;

namespace ApiControllers.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        [HttpGet("string")]
        public string GetString()
        {
            return "This is a string response";
        }

        [HttpGet("object")]
        //[Produces("application/custom")]
        public Reservation MyMethod()
        {
            return new Reservation {ReservationId=100, ClientName="Joe", Location="Board Room" };
        }
    }
}