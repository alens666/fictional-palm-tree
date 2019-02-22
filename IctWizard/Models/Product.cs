using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IctWizard.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public IList<ProductPart> ProductParts { get; set; }



    }
}
