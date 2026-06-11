using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Genero
    {
        [Key]
        public int GeneroCod { get; set; }

        public string GeneroNom { get; set; } = null!;
        public string? GeneroSigla { get; set; }
    }
}
