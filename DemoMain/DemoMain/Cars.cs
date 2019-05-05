namespace DemoMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cars
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Transmission { get; set; }

        [Required]
        [StringLength(50)]
        public string GazType { get; set; }

        public double EngineLitres { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeOfCar { get; set; }

        public int CarManufacturerId { get; set; }

        public int Discount { get; set; }

        [Required]
        [StringLength(150)]
        public string Photos { get; set; }

        public double Price { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }
    }
}
