namespace Capstone.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Utenti")]
    public partial class Utenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utenti()
        {
            Commenti = new HashSet<Commenti>();
            Prenotazione = new HashSet<Prenotazione>();
            Recensioni = new HashSet<Recensioni>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Username Obbligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inserire una Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nome obbligatorio")]
        [Display(Name = "Nome")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Codice fiscale obbligatorio")]
        [StringLength(16)]
        [Display(Name = "Codice Fiscale")]
        public string CF { get; set; }

        [StringLength(13)]
        [Display(Name = "Numero di telefono")]
        public string Telefono { get; set; }

        [StringLength(100)]
        [Display(Name = "Indirizzo Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Ruolo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commenti> Commenti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prenotazione> Prenotazione { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recensioni> Recensioni { get; set; }
    }
}
