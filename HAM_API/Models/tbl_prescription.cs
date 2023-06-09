namespace HAM_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_prescription
    {
        [StringLength(20)]
        public string id { get; set; }

        [StringLength(100)]
        public string disease { get; set; }

        [StringLength(300)]
        public string symptoms { get; set; }

        [StringLength(500)]
        public string medicines { get; set; }

        [StringLength(1000)]
        public string ptu_medicines { get; set; }

        [StringLength(20)]
        public string user_id { get; set; }

        [StringLength(200)]
        public string ptName { get; set; }

        [StringLength(100)]
        public string dcName { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
