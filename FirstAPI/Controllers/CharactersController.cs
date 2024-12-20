using FirstAPI.Data;
using FirstAPI.Models;
using FirstAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    // localhost:mine/api/CharactersController
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        // hi
        public string chact = "IronMan";
        private readonly ApplicationDbContext dbContext;
        public CharactersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllCharacters()
        {
            var AllCharacters = dbContext.Characters.ToList();
            return Ok(AllCharacters);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCharacterById(Guid id) {
            var character = dbContext.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }
        [HttpPost]
        public IActionResult addCharacter(AddCharacterDto addCharacterDto)
        {
            var characterEntity = new Character() {
                Name = addCharacterDto.Name,
                Superpower = addCharacterDto.Superpower,
                Health = addCharacterDto.Health,
                Description = addCharacterDto.Description,
            };

            dbContext.Characters.Add(characterEntity);
            dbContext.SaveChanges();
            return Ok(characterEntity);
        }
        [HttpPut]
        // added
        [Route("{id:guid}")]
        public IActionResult upDateCharacter(Guid id, UpDateCharacterDto UpdateCharacterDto)
        {
            var character = dbContext.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            character.Name = UpdateCharacterDto.Name;
            character.Superpower = UpdateCharacterDto.Superpower;
            character.Health = UpdateCharacterDto.Health;
            dbContext.SaveChanges();
            return Ok(character);   
            }

    }
}
