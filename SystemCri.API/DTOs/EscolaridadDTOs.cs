using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class EscolaridadCreateDto
    {
        public int? EscolaridadCod { get; set; }

        [Required]
        [StringLength(100)]
        public string EscolaridadNom { get; set; } = string.Empty;

        [StringLength(250)]
        public string? EscolaridadDescrip { get; set; }
    }

    public class EscolaridadUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string EscolaridadNom { get; set; } = string.Empty;

        [StringLength(250)]
        public string? EscolaridadDescrip { get; set; }
    }

    public class EscolaridadResponseDto
    {
        public int Id { get; set; }
        public string EscolaridadNom { get; set; } = string.Empty;
        public string? EscolaridadDescrip { get; set; }
    }
}
