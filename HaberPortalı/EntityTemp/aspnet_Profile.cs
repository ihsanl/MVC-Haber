namespace EntityTemp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class aspnet_Profile
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string PropertyNames { get; set; }

        [Required]
        public string PropertyValuesString { get; set; }

        [Required]
        public byte[] PropertyValuesBinary { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}
