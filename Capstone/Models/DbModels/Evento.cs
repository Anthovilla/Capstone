namespace Capstone.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Evento")]
    public partial class Evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evento()
        {
            Commenti = new HashSet<Commenti>();
            Prenotazione = new HashSet<Prenotazione>();
            Recensioni = new HashSet<Recensioni>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        
        public string Nome { get; set; }

        public DateTime? Data { get; set; }

        [StringLength(150)]
        public string Location { get; set; }

        public string Description { get; set; }

        public decimal? Costo { get; set; }

        public int? MaxParticipanti { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [NotMapped]
        public HttpPostedFileBase FotoFile { get; set; }

        public bool Disponibile { get; set; }

        public int FkCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commenti> Commenti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prenotazione> Prenotazione { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recensioni> Recensioni { get; set; }
    }
}
