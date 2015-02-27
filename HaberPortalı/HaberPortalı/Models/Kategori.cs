namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kategori
    {
        public Kategori()
        {
            Ankets = new HashSet<Anket>();
            Habers = new HashSet<Haber>();
            Kategoris1 = new HashSet<Kategori>();
            Yazars = new HashSet<Yazar>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        [Required]
        public string Aciklama { get; set; }

        [Required]
        [StringLength(500)]
        public string Resimyol { get; set; }

        public int UstkategoriId { get; set; }

        public virtual ICollection<Anket> Ankets { get; set; }

        public virtual ICollection<Haber> Habers { get; set; }

        public virtual ICollection<Kategori> Kategoris1 { get; set; }

        public virtual Kategori Kategori1 { get; set; }

        public virtual ICollection<Yazar> Yazars { get; set; }
    }
}
