using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IctWizard.Models
{
    public class SupplierPart
    {
        public int SupplierId { get; set; }
        public int PartId { get; set; }
         
        public Supplier Supplier { get; set; }
        public Part Part { get; set; }

        [Required]
        public int Quantity { get; set; }

    }

}
