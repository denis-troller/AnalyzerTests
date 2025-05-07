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
            return true;
        }

        private bool entityExists(string name)
        {
            var query = "SELECT * FROM Entity1s WHERE Name = {0}";
            var e2 = _ctx.Entity1s.FromSqlRaw(query, name).ToList();
            return e2.Any();
        }
    }
}
