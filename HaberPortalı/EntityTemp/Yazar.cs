namespace EntityTemp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Yazar
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(500)]
        public string Resimyol { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        public int KategoriId { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
