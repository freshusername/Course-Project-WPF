namespace DemoMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarsComments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(1)]
        public string comment { get; set; }

        public DateTime? commented_at { get; set; }

        public int? user_id { get; set; }

        public int? car_id { get; set; }

        public virtual Cars Cars { get; set; }

        public virtual Users Users { get; set; }
    }
}
