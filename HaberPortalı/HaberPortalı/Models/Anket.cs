namespace HaberPortalı.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anket")]
    public partial class Anket
    {
        public Anket()
        {
            AnketSeceneks = new HashSet<AnketSecenek>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        public int KategoriID { get; set; }

        public int Katilimcisayisi { get; set; }

        public DateTime YayimTarihi { get; set; }

        public DateTime SonOyTarihi { get; set; }

        public bool AktifMi { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<AnketSecenek> AnketSeceneks { get; set; }
    }
}
