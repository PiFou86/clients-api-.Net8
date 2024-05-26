using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.DAL.EF.Models
{
    internal class Client
    {
        public Client() { }

        public Client(GC.Entites.Client p_client)
        {
            this.ClientId = p_client.ClientId;
            this.Nom = p_client.Nom;
            this.Prenom = p_client.Prenom;
            this.Adresses = p_client.Adresses?.Select(a => new Adresse(a, p_client.ClientId)).ToList();
        }

        public Guid ClientId { get; set; } = Guid.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Nom { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Prenom { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? DateNaissance { get; set; }
        public virtual ICollection<Adresse>? Adresses { get; set; } = new List<Adresse>();

        public GC.Entites.Client VersEntite()
        {
            List<GC.Entites.Adresse> adresses = this.Adresses?.Select(aDTO => aDTO.VersEntite()).ToList()??new List<Entites.Adresse>();

            return new GC.Entites.Client(this.ClientId, this.Nom, this.Prenom, adresses);
        }
    }
}
