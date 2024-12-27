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
        private readonly ApplicationDbContext dbContext;
        public CharactersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Get all characters
        [HttpGet]
        public IActionResult GetAllCharacters()
        {
            var AllCharacters = dbContext.Characters.ToList();
            return Ok(AllCharacters);
        }
        // Get characters by id
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCharacterById(Guid id)
        {
            var character = dbContext.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }
        // Add characters
        [HttpPost]
        public IActionResult AddCharacter(AddCharacterDto addCharacterDto)
        {
            var characterEntity = new Character()
            {
                Name = addCharacterDto.Name,
                Superpower = addCharacterDto.Superpower,
                Health = addCharacterDto.Health,
                Description = addCharacterDto.Description,
            };

            dbContext.Characters.Add(characterEntity);
            dbContext.SaveChanges();
            return Ok(characterEntity);
        }
        // Update characters
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateCharacter(Guid id, UpdateCharacterDto UpdateCharacterDto)
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
        // Delete characters
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteCharacter(Guid id)
        {
            var character = dbContext.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            dbContext.Characters.Remove(character);
            dbContext.SaveChanges();
            return Ok("Removed successful");

        }
    }
}
// Trying something