namespace HaberPortalı.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Haberportali : DbContext
    {
        public Haberportali()
            : base("name=Haberportali3")
        {
        }

        public virtual DbSet<Anket> Ankets { get; set; }
        public virtual DbSet<AnketSecenek> AnketSeceneks { get; set; }
        public virtual DbSet<Etiket> Etikets { get; set; }
        public virtual DbSet<Goru> Gorus { get; set; }
        public virtual DbSet<Haber> Habers { get; set; }
        public virtual DbSet<HaberTip> HaberTips { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kullanıcı> Kullanıcı { get; set; }
        public virtual DbSet<Resim> Resims { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Yazar> Yazars { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anket>()
                .HasMany(e => e.AnketSeceneks)
                .WithRequired(e => e.Anket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Habers)
                .WithMany(e => e.Etikets)
                .Map(m => m.ToTable("HaberEtiket").MapLeftKey("Etikets_Id").MapRightKey("Habers_Id"));

            modelBuilder.Entity<Goru>()
                .HasMany(e => e.Yorums)
                .WithOptional(e => e.Goru)
                .HasForeignKey(e => e.GorusID);

            modelBuilder.Entity<Haber>()
                .HasMany(e => e.Resims)
                .WithRequired(e => e.Haber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HaberTip>()
                .HasMany(e => e.Habers)
                .WithRequired(e => e.HaberTip)
                .HasForeignKey(e => e.TipID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Ankets)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Habers)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Kategoris1)
                .WithRequired(e => e.Kategori1)
                .HasForeignKey(e => e.UstkategoriId);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Yazars)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Gorus)
                .WithRequired(e => e.Kullanıcı)
                .HasForeignKey(e => e.YazarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Habers)
                .WithOptional(e => e.Kullanıcı)
                .HasForeignKey(e => e.YazarID);

            modelBuilder.Entity<Kullanıcı>()
                .HasOptional(e => e.Yazar)
                .WithRequired(e => e.Kullanıcı);
        }
    }
}
