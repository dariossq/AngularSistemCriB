using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public string UsuarioNombre { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "La descripción no puede exceder 250 caracteres.")]
        public string? UsuarioDescripcion { get; set; }

        public byte[]? UsuarioLogo { get; set; }
        public byte[]? UsuarioPie { get; set; }
        public string? UsuarioEtnia { get; set; }
        public int? UsuarioDepartamento { get; set; }
        public int? UsuarioMunicipio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El estado del usuario debe ser un número válido.")]
        public int UsuarioEstado { get; set; }
    }

    public class UsuarioUpdateDto
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public string UsuarioNombre { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "La descripción no puede exceder 250 caracteres.")]
        public string? UsuarioDescripcion { get; set; }

        public byte[]? UsuarioLogo { get; set; }
        public byte[]? UsuarioPie { get; set; }
        public string? UsuarioEtnia { get; set; }
        public int? UsuarioDepartamento { get; set; }
        public int? UsuarioMunicipio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El estado del usuario debe ser un número válido.")]
        public int UsuarioEstado { get; set; }
    }

    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string? UsuarioDescripcion { get; set; }
        public byte[]? UsuarioLogo { get; set; }
        public byte[]? UsuarioPie { get; set; }
        public string? UsuarioEtnia { get; set; }
        public int? UsuarioDepartamento { get; set; }
        public int? UsuarioMunicipio { get; set; }
        public int UsuarioEstado { get; set; }
    }
}
