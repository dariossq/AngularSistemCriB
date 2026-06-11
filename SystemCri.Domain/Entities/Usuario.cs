using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCri.Domain.Entities;

public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [Required]
    public string UsuarioNombre { get; set; } = null!;

    public string? UsuarioDescripcion { get; set; }
    public byte[]? UsuarioLogo { get; set; }
    public byte[]? UsuarioPie { get; set; }
    public string? UsuarioEtnia { get; set; }

    [ForeignKey(nameof(Departamento))]
    public int? UsuarioDepartamento { get; set; }
    public Depto? Departamento { get; set; }

    [ForeignKey(nameof(Municipio))]
    public int? UsuarioMunicipio { get; set; }
    public Municipio? Municipio { get; set; }

    public int UsuarioEstado { get; set; }

    // Relación con la tabla ACCESO
    public ICollection<Acceso> Accesos { get; set; } = new List<Acceso>();

    // Relación con la tabla VEREDA
    public ICollection<Vereda> Veredas { get; set; } = new List<Vereda>();
}