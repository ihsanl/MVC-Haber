namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Etiket
    {
        public Etiket()
        {
            Habers = new HashSet<Haber>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Adi { get; set; }

        public virtual ICollection<Haber> Habers { get; set; }
    }
}
