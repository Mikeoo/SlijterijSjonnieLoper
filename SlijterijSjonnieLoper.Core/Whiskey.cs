using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SlijterijSjonnieLoper.Core
{
    public class Whiskey
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public WhiskeyBrand Brand { get; set; }
        [Required]
        public WhiskeyType Type { get; set; }
        [Required]
        public WhiskeyArea Area { get; set; }
        [Required]
        public decimal Percentage { get; set; }
        //[Required]
        //public string WhiskeyLabel { get; set; }
        //public bool IsDeleted { get; set; }
        //[Required]
        //public string AreaOptional { get; set; }

    }
}
