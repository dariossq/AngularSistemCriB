using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCri.Domain.Entities
{
    public class Municipio
    {
        // Corresponde a MUNICIPIO_COD (NUMBER 5,0 - No Nullable)
        [Key]
        public int MunicipioCod { get; set; }

        // Corresponde a MUNICIPIO_NOM (VARCHAR2 150 - No Nullable)
        [Required]
        [MaxLength(150)]
        public string MunicipioNom { get; set; } = null!;

        // Corresponde a DEPTO_COD (NUMBER 3,0 - Nullable)
        // FK explícita hacia Depto. Mantengo nullable según tu comentario original.
        [ForeignKey(nameof(Depto))]
        public int? DeptoCod { get; set; }

        // Propiedad de navegación para la relación
        public Depto? Depto { get; set; }
    }
}
