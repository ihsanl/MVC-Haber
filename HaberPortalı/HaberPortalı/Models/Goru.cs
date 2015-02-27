namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goru
    {
        public Goru()
        {
            Yorums = new HashSet<Yorum>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(500)]
        public string Icerik { get; set; }

        public DateTime GorusTarihi { get; set; }

        public int YazarId { get; set; }

        public int Begeni { get; set; }

        public int Tiksinti { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }

        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
