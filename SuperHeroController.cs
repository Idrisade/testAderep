using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> Heroes = new()
        {
            new SuperHero
            {
                Id = 1,
                Name = "Sango",
                FirstName = "Fire",
                LastName = "Lord",
                City = "Osun",
                DateCreated = DateTime.UtcNow
            }
        };

        [HttpGet]
        public ActionResult<SuperHero> getAllHeroes()
        {
            return Ok(Heroes);
        }
        [HttpGet("name")]
        public ActionResult<SuperHero> getSingleHero(string name)
        {
            foreach(SuperHero hero in Heroes)
            {
                if(hero.Name == name) return Ok(hero);  
            }
            return BadRequest($"Hero {name} not found");
        }
        [HttpPost("newHero")]
        public ActionResult<SuperHero> createHero(SuperHero hero)
        {
            //hero.DateCreated = DateTime.UtcNow;
            Heroes.Add(hero);
            return Ok(Heroes);
        }
        [HttpPut("UpdateHero")]
        public ActionResult<SuperHero> updateHero(string name, SuperHeroDto heroDto)
        {
            foreach(SuperHero hero in Heroes)
            {
                if (hero.Name == name)
                {
                    hero.FirstName = heroDto.FirstName;
                    hero.LastName = heroDto.LastName;
                    hero.City = heroDto.City;
                    hero.DateCreated = DateTime.UtcNow;
                    return Ok($"Hero {hero.Name} has been updated successfully");
                }
            }
            return BadRequest($"Hero does not exist");
        }
        [HttpDelete("DeleteHero")]
        public ActionResult<SuperHero> deleteHero(string name)
        {
            foreach(SuperHero hero in Heroes)
            {
                if(hero.Name.Equals(name) )
                {
                    Heroes.Remove(hero);
                    return Ok($"Hero {name} has been removed successfully");
                }
            }
            return BadRequest($"Hero {name} does not exist");
        }

    }
}
