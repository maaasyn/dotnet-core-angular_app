using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DattingApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KotkiController : ControllerBase
    {
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>() {"kotek1", "kotek2" };
        }
    }
}