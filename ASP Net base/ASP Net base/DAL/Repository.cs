﻿using Microsoft.EntityFrameworkCore;

namespace ASP_Net_base.DAL
{
    public class Repository<TEntity>
    where TEntity : class
    {
        private readonly DataContext dataContext;

        protected Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        protected DbSet<TEntity> Set => dataContext.Set<TEntity>();

        public async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
