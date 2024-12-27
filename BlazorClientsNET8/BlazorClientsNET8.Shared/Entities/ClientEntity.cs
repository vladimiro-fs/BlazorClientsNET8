namespace BlazorClientsNET8.Shared.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ClientEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
