namespace DemoMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            CarsComments = new HashSet<CarsComments>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(1)]
        public string email { get; set; }

        [StringLength(1)]
        public string password { get; set; }

        [StringLength(1)]
        public string first_name { get; set; }

        [StringLength(1)]
        public string last_name { get; set; }

        public DateTime? registered_at { get; set; }

        [StringLength(1)]
        public string avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsComments> CarsComments { get; set; }
    }
}
