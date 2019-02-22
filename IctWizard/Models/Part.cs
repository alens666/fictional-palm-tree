using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace IctWizard.Models
{
    public class Part
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public IList<SupplierPart> SupplierParts { get; set; }
        public IList<ProductPart> ProductParts { get; set; }


       }
}
