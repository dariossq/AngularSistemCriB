using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Depto
    {
        // Corresponde a DEPTO_COD (NUMBER 3,0 - No Nullable)
        [Key]
        public int DeptoCod { get; set; }

        // Corresponde a DEPTO_NOM (VARCHAR2 50 - No Nullable)
        public string DeptoNom { get; set; } = null!;

        // Corresponde a DEPTO_DESCRIP (VARCHAR2 100 - Nullable)
        public string? DeptoDescrip { get; set; }
    }
}
