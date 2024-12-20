namespace FirstAPI.Models.Entities
{
    public class Character
    {
        public Guid id { get; set; }
        public required string Name { get; set; }   
        public required int Health {  get; set; }
        public required string Superpower { get; set; }  
        public string? Description { get; set; } 

    }
}
