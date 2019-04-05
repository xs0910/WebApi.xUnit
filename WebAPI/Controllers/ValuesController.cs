using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value:{id}";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post(dynamic obj)
        {
            return $"姓名：{obj.Name},年龄：{obj.Age}";
        }
    }
}
