using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class AccesoCreateDto
    {
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaIAcceso { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateTime FechaFAcceso { get; set; }

        [Required(ErrorMessage = "El usuario asociado es obligatorio.")]
        public int UsuarioId { get; set; }
    }

    public class AccesoUpdateDto
    {
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaIAcceso { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateTime FechaFAcceso { get; set; }

        [Required(ErrorMessage = "El usuario asociado es obligatorio.")]
        public int UsuarioId { get; set; }
    }

    public class AccesoResponseDto
    {
        public int Id { get; set; }
        public DateTime FechaIAcceso { get; set; }
        public DateTime FechaFAcceso { get; set; }
        public int UsuarioId { get; set; }
    }
}
