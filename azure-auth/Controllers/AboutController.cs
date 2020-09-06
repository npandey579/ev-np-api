using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace azureauth.Controllers
{
    [Route("api")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public ContentResult About()
        {
            return Content("An API listing events");
        }
    }
}
