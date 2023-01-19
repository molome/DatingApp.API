using DatingApp.API.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public RecordController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var records = _db.Records.ToList();
            return Ok(records);
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var record = _db.Records.Find(id);
            return Ok(record);
        }
    }
}
