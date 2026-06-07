using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class MunicipioCreateDto
    {
        [Required(ErrorMessage = "El nombre del municipio es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder 150 caracteres.")]
        public string MunicipioNom { get; set; } = string.Empty;

        // Nullable: si quieres obligarlo, cambia a int y añade [Required]
        public int? DeptoCod { get; set; }
    }

    public class MunicipioResponseDto
    {
        public int Id { get; set; }
        public string MunicipioNom { get; set; } = string.Empty;
        public int? DeptoCod { get; set; }
    }
}
