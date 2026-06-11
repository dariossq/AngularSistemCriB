using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class GeneroCreateDto
    {
        public int? GeneroCod { get; set; }

        [Required]
        [StringLength(100)]
        public string GeneroNom { get; set; } = string.Empty;

        [StringLength(10)]
        public string? GeneroSigla { get; set; }
    }

    public class GeneroUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string GeneroNom { get; set; } = string.Empty;

        [StringLength(10)]
        public string? GeneroSigla { get; set; }
    }

    public class GeneroResponseDto
    {
        public int Id { get; set; }
        public string GeneroNom { get; set; } = string.Empty;
        public string? GeneroSigla { get; set; }
    }
}
