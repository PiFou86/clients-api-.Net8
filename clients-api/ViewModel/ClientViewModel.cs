using GC.Entites;
using System.ComponentModel.DataAnnotations;

namespace clients_api.ViewModel
{

    public class ClientViewModel
    {
        public ClientViewModel() { }

        public ClientViewModel(Client p_client)
        {
            this.ClientId = p_client.ClientId;
            this.Nom = p_client.Nom;
            this.Prenom = p_client.Prenom;
            this.DateNaissance = p_client.DateNaissance;
            this.Adresses = p_client.Adresses?.ConvertAll(a => new AdresseViewModel(a)).ToList() ?? new List<AdresseViewModel>();
        }

        public Guid? ClientId { get; set; } = Guid.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Nom { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Prenom { get; set; } = string.Empty;
        [Required]
        public DateTime? DateNaissance { get; set; } = DateTime.Now;
        public List<AdresseViewModel>? Adresses { get; set; }

        public Client ToEntity() { 
            Client client = new Client(ClientId ?? Guid.Empty, Nom, Prenom, DateNaissance, Adresses?.ConvertAll(a => a.ToEntity()) ?? new List<Adresse>());

            return client;
        }
    }
}
