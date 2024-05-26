using System;
using System.ComponentModel.DataAnnotations;

namespace GC.Entites
{
    public class Adresse
    {
        public Guid AdresseId { get; set; }
        [Required]
        public int NumeroCivique { get; set; }
        public string? InformationSupplementaire { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Odonyme { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string TypeVoie { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string CodePostal { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string NomMunicipalite { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Etat { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Pays { get; set; }

        public Adresse(Guid p_AdresseId, int p_numeroCivique, string? p_informationSupplementaire, string p_odonyme, string p_typeVoie, string p_codePostal,
            string p_nomMunicipalite, string p_etat, string p_pays)
        {
            if (p_AdresseId == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(p_AdresseId));
            }
            if (string.IsNullOrWhiteSpace(p_codePostal))
            {
                throw new ArgumentOutOfRangeException(nameof(p_codePostal));
            }
            if (string.IsNullOrWhiteSpace(p_nomMunicipalite))
            {
                throw new ArgumentOutOfRangeException(nameof(p_nomMunicipalite));
            }
            if (string.IsNullOrWhiteSpace(p_pays))
            {
                throw new ArgumentOutOfRangeException(nameof(p_pays));
            }

            this.AdresseId = p_AdresseId;
            this.NumeroCivique = p_numeroCivique;
            this.InformationSupplementaire = p_informationSupplementaire;
            this.Odonyme = p_odonyme;
            this.TypeVoie = p_typeVoie;
            this.CodePostal = p_codePostal;
            this.NomMunicipalite = p_nomMunicipalite;
            this.Etat = p_etat;
            this.Pays = p_pays;
        }
    }
}
