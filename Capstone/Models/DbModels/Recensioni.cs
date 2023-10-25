namespace Capstone.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recensioni")]
    public partial class Recensioni
    {
        public int Id { get; set; }

        public int? Rating { get; set; }

        public string Text { get; set; }

        public int FKEventi { get; set; }

        public int FKUtenti { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
