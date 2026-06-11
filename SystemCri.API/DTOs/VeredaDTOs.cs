using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class VeredaCreateDto
    {
        [Required(ErrorMessage = "El nombre de la vereda es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public string VeredaNom { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "La ubicación no puede exceder 1000 caracteres.")]
        public string? VeredaUbicacion { get; set; }

        public int? UsuarioId { get; set; }
    }

    public class VeredaUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la vereda es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public string VeredaNom { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "La ubicación no puede exceder 1000 caracteres.")]
        public string? VeredaUbicacion { get; set; }

        public int? UsuarioId { get; set; }
    }

    public class VeredaResponseDto
    {
        public int Id { get; set; }
        public string VeredaNom { get; set; } = string.Empty;
        public string? VeredaUbicacion { get; set; }
        public int? UsuarioId { get; set; }
    }
}
