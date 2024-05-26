using System;
using System.Collections.Generic;

namespace GC.Entites
{
    public interface IDepotClients
    {
        void AjouterClient(Client p_client);
        List<Client> ListerClients(PagingParameters pagingParameters);
        Client? ObtenirClient(Guid p_guid);
        void ModifierClient(Client p_client);
        void EffacerClient(Guid id);

        public void AjouterAdresse(Guid p_clientId, Adresse p_adresse);
        IEnumerable<Adresse> ListerAdresses(Guid clientId, PagingParameters pagingParameters);
        public Adresse? ObtenirAdresse(Guid p_clientId, Guid p_adresseId);
        public void ModifierAdresse(Guid p_clientId, Adresse p_adresse);
        public void EffacerAdresse(Guid p_clientId, Guid p_adresseId);
    }
}
