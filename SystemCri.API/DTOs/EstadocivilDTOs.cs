using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class EstadocivilCreateDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "El nombre no puede exceder 20 caracteres")]
        public string EstadocNom { get; set; } = null!;

        [StringLength(100, ErrorMessage = "La descripción no puede exceder 100 caracteres")]
        public string? EstadocDescrip { get; set; }
    }

    public class EstadocivilUpdateDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "El nombre no puede exceder 20 caracteres")]
        public string EstadocNom { get; set; } = null!;

        [StringLength(100, ErrorMessage = "La descripción no puede exceder 100 caracteres")]
        public string? EstadocDescrip { get; set; }
    }

    public class EstadocivilResponseDto
    {
        public int Id { get; set; }
        public string EstadocNom { get; set; } = null!;
        public string? EstadocDescrip { get; set; }
    }
}
