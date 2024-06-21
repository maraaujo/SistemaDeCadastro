using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Domain.Context;
using SistemaDeCadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Data.Repository
{
    public class BaseRepository<T> where T : class
    {
        public SitemaDeCadastroContext context { get; set; }
        public BaseRepository(SitemaDeCadastroContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);

            // await context.Idosos.AddAsync(idoso);
            await context.SaveChangesAsync();
        }


        public async Task<List<T>> FindBy(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync();
        }

    }
}
