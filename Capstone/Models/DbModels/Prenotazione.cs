namespace Capstone.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prenotazione")]
    public partial class Prenotazione
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        public int? Partecipanti { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int FKEventi { get; set; }

        public int FKUtente { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
