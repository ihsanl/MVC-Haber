namespace EntityTemp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Yorum
    {
        public int Id { get; set; }

        public int? HaberId { get; set; }

        public int? GorusID { get; set; }

        [Required]
        public string Baslik { get; set; }

        public int Ip { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad_Soyad { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        public string Icerik { get; set; }

        public DateTime Tarih { get; set; }

        public bool Onayli { get; set; }

        public int Begeni { get; set; }

        public int Tiksinti { get; set; }

        public virtual Goru Goru { get; set; }

        public virtual Haber Haber { get; set; }
    }
}
