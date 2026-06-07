using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class DeptoCreateDto
    {
        [Required(ErrorMessage = "El nombre del departamento es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
        public string DeptoNom { get; set; } = string.Empty;
        [StringLength(100, ErrorMessage = "La descripción no puede exceder 100 caracteres.")]
        public string? DeptoDescrip { get; set; }
    }

    public class DeptoResponseDto
    {
        public int Id { get; set; }
        public string DeptoNom { get; set; } = string.Empty;
        public string? DeptoDescrip { get; set; }
    }
}
