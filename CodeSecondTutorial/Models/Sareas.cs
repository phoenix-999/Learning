namespace CodeSecondTutorial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sareas
    {
        [Key]
        public int SareaId { get; set; }

        public string SareaName { get; set; }

        public int? User_UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
