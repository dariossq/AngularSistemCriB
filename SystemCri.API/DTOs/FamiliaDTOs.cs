using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class FamiliaCreateDto
    {
        public int? FamCod { get; set; }

        [Required]
        [StringLength(100)]
        public string FamNombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? FamDescrip { get; set; }
    }

    public class FamiliaUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string FamNombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? FamDescrip { get; set; }
    }

    public class FamiliaResponseDto
    {
        public int Id { get; set; }
        public string FamNombre { get; set; } = string.Empty;
        public string? FamDescrip { get; set; }
    }
}
