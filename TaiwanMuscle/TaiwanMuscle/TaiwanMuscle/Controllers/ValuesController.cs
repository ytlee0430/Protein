using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaiwanMuscle.Models;
using TaiwanMuscle.ReponseModels;

namespace TaiwanMuscle.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json", "multipart/form-data")]//允许文件上传
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProteinsContext _proteinContext;

        //Cookies
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValuesController(ProteinsContext proteinContext, IHttpContextAccessor httpContextAccessor)
        {
            _proteinContext = proteinContext;
            _httpContextAccessor = httpContextAccessor;
            //_httpContextAccessor.HttpContext.Request.Cookies
        }

        /// <summary>
        /// 取得所有有庫存乳清
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("P001")]
        public ActionResult<Result<List<P001>>> GetProteinInfos()
        {
            var result = _proteinContext.ProteinData.Where(x => x.Stock > 0).Select(x => new P001()
            {
                Id = x.Id,
                Stock = x.Stock,
                Favor = x.Favor,
                Price = x.Price * x.Discount,
                Brand = x.Brand
            }).ToList();

            return new Result<List<P001>>() { ok = 1, data = result };
        }

        /// <summary>
        /// 取得所有護具產品
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("P002")]
        public ActionResult<Result<List<P002>>> GetBracesInfos()
        {
            var a = new Result<List<P002>>() { ok = 1 };
            return a;
        }

        /// <summary>
        /// 取得特定產品資訊
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("P003")]
        public ActionResult<Result<List<P003>>> GetSpecificProductInfo()
        {
            var a = new Result<List<P003>>() { ok = 1 };
            return a;
        }

        /// <summary>
        /// 取得未結帳產品項目
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("P004")]
        public ActionResult<Result<List<P004>>> GetShoppingCartProducts()
        {
            //TODO: 從cookie拿
            var a = new Result<List<P004>>() { ok = 1 };
            return a;
        }

        /// <summary>
        /// 取得購買紀錄
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("P005")]
        public ActionResult<Result<List<P005>>> GetPurchaseHistoryInfos()
        {
            var a = new Result<List<P005>>() { ok = 1 };
            return a;
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
            var x = _proteinContext.ProteinData.Where(a => a.Id == 0).FirstOrDefault();
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
