namespace MVCDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Courses
    {
        public int id { get; set; }

        public int currency_id { get; set; }

        public double buy { get; set; }

        public double sell { get; set; }
    }
}
