using GC.Entites;
using GC.GenererDonnees;

namespace GC.BL
{
    public class GestionClientsBL
    {
        private IDepotClients m_depotClients;
        public GestionClientsBL(IDepotClients p_depotClients)
        {
            if (p_depotClients is null)
            {
                throw new ArgumentNullException(nameof(p_depotClients));
            }

            this.m_depotClients = p_depotClients;
        }

        public List<Client> ObtenirClients(PagingParameters pagingParameters)
        {
            return this.m_depotClients.ListerClients(pagingParameters);
        }

        public void GenererEtAjouterClientsPourDemos(int p_nombreClients = 5)
        {
            if (p_nombreClients <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_nombreClients));
            }

            List<Client> clients = GenerateurDonnees.GenererClients(p_nombreClients);
            clients.ForEach(c => this.m_depotClients.AjouterClient(c));
        }

        public Client? ObtenirClient(Guid id)
        {
            return this.m_depotClients.ObtenirClient(id);
        }

        public void EffacerClient(Guid id)
        {
            this.m_depotClients.EffacerClient(id);
        }

        public void ModifierClient(Client client)
        {
            UpSertClient(client);
        }

        public void AjouterClient(Client client)
        {
            UpSertClient(client);
        }

        private void UpSertClient(Client client)
        {
            if (client is null || client.ClientId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Client? clientBD = this.ObtenirClient(client.ClientId);

            if (clientBD is null)
            {
                this.m_depotClients.AjouterClient(client);
            }
            else
            {
                this.m_depotClients.ModifierClient(client);
            }
        }

        public IEnumerable<Adresse> ListerAdresses(Guid clientId, PagingParameters pagingParameters)
        {
            return this.m_depotClients.ListerAdresses(clientId, pagingParameters);
        }

        public Adresse? ObtenirAdresse(Guid clientId, Guid id)
        {
            return this.m_depotClients.ObtenirAdresse(clientId, id);
        }

        public void AjouterAdresse(Guid clientId, Adresse adresse)
        {
            this.UpSertAdresse(clientId, adresse);
        }

        public void ModifierAdresse(Guid clientId, Adresse adresse)
        {
            this.UpSertAdresse(clientId, adresse);
        }

        private void UpSertAdresse(Guid clientId, Adresse adresse)
        {
            if (adresse is null || adresse.AdresseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(adresse));
            }

            Adresse? adresseBD = this.ObtenirAdresse(clientId, adresse.AdresseId);

            if (adresseBD is null)
            {
                this.m_depotClients.AjouterAdresse(clientId, adresse);
            }
            else
            {
                this.m_depotClients.ModifierAdresse(clientId, adresse);
            }
        }

        public void EffacerAdresse(Guid clientId, Guid id)
        {
            this.m_depotClients.EffacerAdresse(clientId, id);
        }
    }
}