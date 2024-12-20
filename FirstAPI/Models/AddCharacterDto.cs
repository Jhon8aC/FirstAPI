namespace FirstAPI.Models
{
    public class AddCharacterDto
    {
        public required string Name { get; set; }
        public required int Health { get; set; }
        public required string Superpower { get; set; }
        public string? Description { get; set; }
    }
}
