﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaiwanMuscle.Models;

namespace TaiwanMuscle.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json", "multipart/form-data")]//允许文件上传
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProteinsContext _proteinsContext;
        public ValuesController(ProteinsContext proteinsContext)
        {
            _proteinsContext = proteinsContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(TestParam test)
        {
            var x = _proteinsContext.ProteinData.Where(a => a.Id == 0).FirstOrDefault();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class TestParam
    {
        public string Test { get; set; }
    }
}
