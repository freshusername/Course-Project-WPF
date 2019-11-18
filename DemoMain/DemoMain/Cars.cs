namespace DemoMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            CarDiscounts = new HashSet<CarDiscounts>();
            CarsComments = new HashSet<CarsComments>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? manuf_id { get; set; }

        [StringLength(1)]
        public string model { get; set; }

        [StringLength(1)]
        public string color { get; set; }

        public DateTime? year { get; set; }

        public bool? IsForSale { get; set; }

        public int? transmission_id { get; set; }

        public int? engine_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarDiscounts> CarDiscounts { get; set; }

        public virtual CarManufs CarManufs { get; set; }

        public virtual Engines Engines { get; set; }

        public virtual Transmissions Transmissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsComments> CarsComments { get; set; }
    }
}
