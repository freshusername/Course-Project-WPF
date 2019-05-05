namespace DemoMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Offers
    {
        [Key]
        [StringLength(40)]
        public string Owner { get; set; }

        [Required]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [StringLength(13)]
        public string PhoneNumber { get; set; }

        public float Price { get; set; }

        public int Discount { get; set; }

        public int? CarId { get; set; }
    }
}
