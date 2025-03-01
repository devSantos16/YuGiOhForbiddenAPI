using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using YuGiOhForbiddenAPI.Model;
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

        [HttpGet]
        public IActionResult GetAllCards()
        {
            var cards = this._context.Card.ToList();
            
            if (cards.Any() == false) 
            {
                return NotFound("Not Found");
            }

            return Ok(cards);
        }

        [HttpPost]
        public IActionResult Post(Card card)
        {
            var cards = this._context.Card;
            
            cards.Add(card);
            this._context.SaveChanges();

            return Ok(cards);
        }
    }
}
