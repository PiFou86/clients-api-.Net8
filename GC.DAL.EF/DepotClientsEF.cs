using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GC.DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace GC.DAL.EF
{
    // TODO :
    // 1. Séparer client et adresse en deux classes
    // 2. Ajouter les transactions
    // 3. Ajouter les tests unitaires
    public class DepotClientsEF : GC.Entites.IDepotClients, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public DepotClientsEF(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public void AjouterClient(GC.Entites.Client p_client)
        {
            this._context.Add<Client>(new Client(p_client));
            this._context.SaveChanges();
        }

        public List<GC.Entites.Client> ListerClients(Entites.PagingParameters pagingParameters)
        {
            if (pagingParameters is null)
            {
                throw new ArgumentNullException(nameof(pagingParameters));
            }
            pagingParameters.Normalize();

            if (pagingParameters.Page > 0)
            {
                return this._context.Client
                    .Include(c => c.Adresses)
                    .Skip(pagingParameters.Page * pagingParameters.PageSize)
                    .Take(pagingParameters.PageSize)
                    .Select(c => c.VersEntite()).ToList();
            }

            return this._context.Client
                .Include(c => c.Adresses)
                .Select(c => c.VersEntite()).ToList();
        }

        public void ModifierClient(GC.Entites.Client p_client)
        {
            this._context.Update<Client>(new Client(p_client));
            this._context.SaveChanges();
        }

        public GC.Entites.Client? ObtenirClient(Guid p_guid)
        {
            return this._context.Client.Include(c => c.Adresses).SingleOrDefault(c => c.ClientId == p_guid)?.VersEntite();
        }

        public void EffacerClient(Guid p_guid)
        {
            this._context.Remove<Client>(new Client() { ClientId = p_guid });
            this._context.SaveChanges();
        }

        public void AjouterAdresse(Guid p_clientId, GC.Entites.Adresse p_adresse)
        {
            this._context.Add<Adresse>(new Adresse(p_adresse, p_clientId));
            this._context.SaveChanges();
        }

        public GC.Entites.Adresse? ObtenirAdresse(Guid p_clientId, Guid p_adresseId)
        {
            return this._context.Adresse.SingleOrDefault(a => a.ClientId == p_clientId && a.AdresseId == p_adresseId)?.VersEntite();
        }

        public IEnumerable<Entites.Adresse> ListerAdresses(Guid clientId, Entites.PagingParameters pagingParameters)
        {
            if (pagingParameters is null)
            {
                throw new ArgumentNullException(nameof(pagingParameters));
            }

            pagingParameters.Normalize();
            if (pagingParameters.Page > 0)
            {
                return this._context.Adresse.Where(a => a.ClientId == clientId)
                            .Skip(pagingParameters.Page * pagingParameters.PageSize)
                            .Take(pagingParameters.PageSize)
                            .Select(a => a.VersEntite()).ToList();
            }

            return this._context.Adresse.Where(a => a.ClientId == clientId)
            .Select(a => a.VersEntite()).ToList();
        }

        public void ModifierAdresse(Guid p_clientId, GC.Entites.Adresse p_adresse)
        {
            this._context.Update<Adresse>(new Adresse(p_adresse, p_clientId));
            this._context.SaveChanges();
        }

        public void EffacerAdresse(Guid p_clientId, Guid p_adresseId)
        {
            this._context.Remove<Adresse>(new Adresse() { ClientId = p_clientId, AdresseId = p_adresseId });
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
