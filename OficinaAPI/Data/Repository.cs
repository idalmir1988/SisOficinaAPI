using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;            
        }

        public Cliente[] GetAllClientes()
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return query.ToArray();
        }

        public Cliente GetClienteById(int id)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.AsNoTracking().Where(c => c.Id == id);

            return query.FirstOrDefault();
        }

        public OrdemServico[] GetOrdensServicos()
        {
            IQueryable<OrdemServico> query = _context.OrdensServicos;

            query = query.Include(os => os.Cliente);

            query = query.AsNoTracking().OrderBy(os => os.Id);

            return query.ToArray();
        }

        public OrdemServico GetOrdemServicoById(int id)
        {
            IQueryable<OrdemServico> query = _context.OrdensServicos;            

            query = query.AsNoTracking().Where(os => os.Id == id);

            return query.FirstOrDefault();
        }

        public Tecnico[] GetAllTecnicos()
        {
            IQueryable<Tecnico> query = _context.Tecnicos;
            query = query.AsNoTracking().OrderBy(tec => tec.Id);
            return query.ToArray();
        }

        public Tecnico GetTecnicoById(int id)
        {
            IQueryable<Tecnico> query = _context.Tecnicos;
            query = query.AsNoTracking().Include(os => os.OrdemServicos);
            return query.FirstOrDefault();
        }
    }
}
