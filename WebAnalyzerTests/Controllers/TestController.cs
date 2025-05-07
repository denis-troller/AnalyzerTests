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
        public Entity1 GetEntity()
        {
            return new Entity1();
        }

        private Entity1 getEntity(string name)
        {
            //var e1 = _ctx.Database.SqlQuery<Entity1>($"SELECT * FROM Entity1s WHERE Name = {name}").ToList();
            var e2 = _ctx.Database.SqlQueryRaw<Entity1>($"SELECT * FROM Entity1s WHERE Name = {name}").ToList();
            var res1 = e2.First();
            return e2.First();
        }
    }
}
