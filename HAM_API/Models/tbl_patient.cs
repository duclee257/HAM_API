namespace HAM_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_patient()
        {
            tbl_booking = new HashSet<tbl_booking>();
        }

        [StringLength(1)]
        public string id { get; set; }

        [StringLength(1)]
        public string pt_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dob { get; set; }

        [StringLength(1)]
        public string gender { get; set; }

        [StringLength(1)]
        public string job { get; set; }

        [StringLength(1)]
        public string address { get; set; }

        [StringLength(1)]
        public string user_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_booking> tbl_booking { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}