namespace EntityTemp
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
        [StringLength(150)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(500)]
        public string Icerik { get; set; }

        public DateTime GorusTarihi { get; set; }

        public Guid YazarId { get; set; }

        public int Begeni { get; set; }

        public int Tiksinti { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
