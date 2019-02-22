using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IctWizard.Models
{
    public class ProductPart
    {
        public int ProductId { get; set; }
        public int PartId { get; set; }

        public Product Product { get; set; }
        public Part Part { get; set; }

        [Required]
        public int Quantity { get; set; }


    }
}
