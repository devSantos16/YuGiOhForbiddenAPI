using Microsoft.AspNetCore.Mvc;
using YuGiOhForbiddenAPI.Persistence;

namespace YuGiOhForbiddenAPI.Controllers
{
    [Route("api/yu-gi-oh-forbidden-api")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly YuGiOhDbContext _context;

        public Controller(YuGiOhDbContext context)
        {
            this._context = context;
        }
    }
}
