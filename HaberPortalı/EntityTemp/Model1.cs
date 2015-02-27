namespace EntityTemp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Anket> Ankets { get; set; }
        public virtual DbSet<AnketSecenek> AnketSeceneks { get; set; }
        public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual DbSet<aspnet_Paths> aspnet_Paths { get; set; }
        public virtual DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
        public virtual DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public virtual DbSet<aspnet_Profile> aspnet_Profile { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
        public virtual DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
        public virtual DbSet<Etiket> Etikets { get; set; }
        public virtual DbSet<Goru> Gorus { get; set; }
        public virtual DbSet<Haber> Habers { get; set; }
        public virtual DbSet<HaberTip> HaberTips { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Resim> Resims { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Yazar> Yazars { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anket>()
                .Property(e => e.AktifMi)
                .IsFixedLength();

            modelBuilder.Entity<Anket>()
                .HasMany(e => e.AnketSeceneks)
                .WithRequired(e => e.Anket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Paths)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Roles)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Users)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Paths>()
                .HasOptional(e => e.aspnet_PersonalizationAllUsers)
                .WithRequired(e => e.aspnet_Paths);

            modelBuilder.Entity<aspnet_Roles>()
                .HasMany(e => e.aspnet_Users)
                .WithMany(e => e.aspnet_Roles)
                .Map(m => m.ToTable("aspnet_UsersInRoles"));

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Profile)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_Users>()
                .HasMany(e => e.Gorus)
                .WithRequired(e => e.aspnet_Users)
                .HasForeignKey(e => e.YazarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Users>()
                .HasMany(e => e.Habers)
                .WithOptional(e => e.aspnet_Users)
                .HasForeignKey(e => e.YazaID);

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.Yazar)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventSequence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventOccurrence)
                .HasPrecision(19, 0);

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
        }
    }
}
