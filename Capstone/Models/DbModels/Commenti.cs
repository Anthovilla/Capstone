namespace Capstone.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Commenti")]
    public partial class Commenti
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime? Data { get; set; }

        public int FKEventi { get; set; }

        public int FKUser { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
