namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HaberTip
    {
        public HaberTip()
        {
            Habers = new HashSet<Haber>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Adi { get; set; }

        public virtual ICollection<Haber> Habers { get; set; }
    }
}
