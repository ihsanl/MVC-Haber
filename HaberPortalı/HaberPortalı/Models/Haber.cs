namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Haber
    {
        public Haber()
        {
            Resims = new HashSet<Resim>();
            Yorums = new HashSet<Yorum>();
            Etikets = new HashSet<Etiket>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Baslik { get; set; }

        [Required]
        public string Ozet { get; set; }

        [Required]
        public string Icerik { get; set; }

        public DateTime Yayim_Tarihi { get; set; }

        public int KategoriID { get; set; }

        [StringLength(200)]
        public string Videoyol { get; set; }

        public int TipID { get; set; }

        [Required]
        [StringLength(50)]
        public string Resimyol { get; set; }

        [Required]
        [StringLength(50)]
        public string Kucukresimyol { get; set; }

        public int Goruntuleme { get; set; }

        public int? YazarID { get; set; }

        public virtual HaberTip HaberTip { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }

        public virtual ICollection<Resim> Resims { get; set; }

        public virtual ICollection<Yorum> Yorums { get; set; }

        public virtual ICollection<Etiket> Etikets { get; set; }
    }
}
