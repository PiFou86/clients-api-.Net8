using GC.Entites;
using System.ComponentModel.DataAnnotations;

namespace clients_api.ViewModel
{
    public class AdresseViewModel
    {
        public Guid? AdresseId { get; set; }
        [Required]
        public int NumeroCivique { get; set; }
        public string? InformationSupplementaire { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Odonyme { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string TypeVoie { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string CodePostal { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string NomMunicipalite { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Etat { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Pays { get; set; } = string.Empty;

        public AdresseViewModel()
        {
            ;
        }

        public AdresseViewModel(Adresse adresse)
        {
            AdresseId = adresse.AdresseId;
            NumeroCivique = adresse.NumeroCivique;
            InformationSupplementaire = adresse.InformationSupplementaire;
            Odonyme = adresse.Odonyme;
            TypeVoie = adresse.TypeVoie;
            CodePostal = adresse.CodePostal;
            NomMunicipalite = adresse.NomMunicipalite;
            Etat = adresse.Etat;
            Pays = adresse.Pays;
        }

        internal Adresse ToEntity()
        {
            return new Adresse(AdresseId ?? Guid.Empty, NumeroCivique, InformationSupplementaire, Odonyme, TypeVoie, CodePostal, NomMunicipalite, Etat, Pays);
        }
    }
}