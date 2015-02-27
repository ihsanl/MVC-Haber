namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnketSecenek")]
    public partial class AnketSecenek
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int AnketID { get; set; }

        [Required]
        [StringLength(500)]
        public string Metin { get; set; }

        public int Oysayisi { get; set; }

        public int Sira { get; set; }

        public virtual Anket Anket { get; set; }
    }
}
