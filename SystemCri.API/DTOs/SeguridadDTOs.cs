using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class SeguridadCreateDto
    {
        public int? PerCod { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [StringLength(100, ErrorMessage = "El usuario no puede exceder 100 caracteres.")]
        public string SeguridadPer { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, ErrorMessage = "La contraseña no puede exceder 100 caracteres.")]
        public string SeguridadContra { get; set; } = string.Empty;
    }

    public class SeguridadUpdateDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [StringLength(100, ErrorMessage = "El usuario no puede exceder 100 caracteres.")]
        public string SeguridadPer { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, ErrorMessage = "La contraseña no puede exceder 100 caracteres.")]
        public string SeguridadContra { get; set; } = string.Empty;
    }

    public class SeguridadResponseDto
    {
        public int Id { get; set; }
        public int PerCod { get; set; }
        public string SeguridadPer { get; set; } = string.Empty;
        public string SeguridadContra { get; set; } = string.Empty;
    }
}
