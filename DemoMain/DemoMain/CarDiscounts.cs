namespace DemoMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarDiscounts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? car_id { get; set; }

        public DateTime? discount_expires { get; set; }

        public double? discount { get; set; }

        public virtual Cars Cars { get; set; }
    }
}
