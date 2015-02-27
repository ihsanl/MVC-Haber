namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kullanıcı
    {
        public Kullanıcı()
        {
            Gorus = new HashSet<Goru>();
            Habers = new HashSet<Haber>();
        }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KullanıcıId { get; set; }

        public virtual ICollection<Goru> Gorus { get; set; }

        public virtual ICollection<Haber> Habers { get; set; }

        public virtual Yazar Yazar { get; set; }
    }
}
