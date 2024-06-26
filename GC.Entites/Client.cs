﻿using System;
using System.Collections.Generic;

namespace GC.Entites
{
    public class Client
    {
        private List<Adresse> m_adresses;
        public Guid ClientId { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public List<Adresse> Adresses
        {
            get { return new List<Adresse>(this.m_adresses); }
            private set { this.m_adresses = value; }
        }

        public DateTime? DateNaissance { get; set; }

        public Client(Guid p_clientId, string p_nom, string p_prenom, DateTime? p_dateNaissance, IEnumerable<Adresse> p_adresses)
        {
            if (p_clientId == Guid.Empty)
            {
                p_clientId = Guid.NewGuid();
            }
            if (string.IsNullOrWhiteSpace(p_nom))
            {
                throw new ArgumentOutOfRangeException(nameof(p_nom));
            }
            if (string.IsNullOrWhiteSpace(p_prenom))
            {
                throw new ArgumentOutOfRangeException(nameof(p_prenom));
            }
            if (p_adresses is null)
            {
                throw new ArgumentNullException(nameof(p_adresses));
            }

            this.ClientId = p_clientId;
            this.Nom = p_nom;
            this.Prenom = p_prenom;
            this.DateNaissance = p_dateNaissance;
            this.m_adresses = [.. p_adresses];
        }

        public void AjouterModifierAdresse(Adresse p_adresse)
        {
            if (p_adresse is null)
            {
                throw new ArgumentNullException(nameof(p_adresse));
            }
            this.m_adresses.RemoveAll(a => a.AdresseId == p_adresse.AdresseId);
            this.m_adresses.Add(p_adresse);
        }
    }
}
