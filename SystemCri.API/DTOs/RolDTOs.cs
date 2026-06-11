using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class RolCreateDto
    {
        public int? RolCod { get; set; }

        [Required]
        [StringLength(20)]
        public string RolNom { get; set; } = string.Empty;

        [StringLength(50)]
        public string? RolDescrip { get; set; }
    }

    public class RolUpdateDto
    {
        [Required]
        [StringLength(20)]
        public string RolNom { get; set; } = string.Empty;

        [StringLength(50)]
        public string? RolDescrip { get; set; }
    }

    public class RolResponseDto
    {
        public int Id { get; set; }
        public string RolNom { get; set; } = string.Empty;
        public string? RolDescrip { get; set; }
    }
}
