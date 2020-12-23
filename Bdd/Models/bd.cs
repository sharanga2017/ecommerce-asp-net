namespace Bdd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd")]
    public partial class bd
    {
        [Key]
        [Column("ref")]
        [StringLength(50)]
        public string _ref { get; set; }

        public byte[] image { get; set; }

        [StringLength(50)]
        public string heros { get; set; }

        [StringLength(50)]
        public string titre { get; set; }

        public double? prixPublic { get; set; }

        [Column(TypeName = "text")]
        public string resume { get; set; }

        public int? idSerie { get; set; }

        public int? idGenre { get; set; }
    }
}
