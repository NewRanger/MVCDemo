namespace MVCDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Currency")]
    public partial class Currency
    {
        public int id { get; set; }

        [Required]
        [StringLength(3)]
        public string code { get; set; }

        [Required]
        [StringLength(25)]
        public string name { get; set; }

        [Required]
        [StringLength(25)]
        public string name_lat { get; set; }

        public int order_index { get; set; }
    }
}
