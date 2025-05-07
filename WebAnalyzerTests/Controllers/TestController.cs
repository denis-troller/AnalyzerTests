using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAnalyzerTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly MyDBContext _ctx;
        public TestController(MyDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public bool GetEntity(string name)
        {
            return entityExists(name);
        }

        private bool entityExists(string name)
        {
            var query = $"SELECT Id FROM Entity1s WHERE Name = '" + name + "'";
            var e2 = _ctx.Database.SqlQueryRaw<int>(query).ToList();
            return e2.Any();
        }
    }
}
