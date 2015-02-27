namespace EntityTemp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int HaberID { get; set; }

        [Required]
        [StringLength(500)]
        public string Ozet { get; set; }

        [Required]
        [StringLength(500)]
        public string Resimyol { get; set; }

        public virtual Haber Haber { get; set; }
    }
}
