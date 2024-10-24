﻿using E_Commerce.Infrastructure.Data;
using E_Commerce.SharedKernal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain
{
    public class GenericRepository<T, Tkey> : IGenericRepository<T, Tkey>
        where T : Entity<Tkey>
        where Tkey : ValueObjectId
    {
        public  ApplicationContext _context;

        protected GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            var res = await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public virtual async Task Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(Tkey id,bool withTracking = false)
        {
            return withTracking?
                await _context.Set<T>().FirstOrDefaultAsync(e => EF.Property<Tkey>(e, nameof(Entity<Tkey>.Id))!.Equals(id)) ?? null
                : await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => EF.Property<Tkey>(e, nameof(Entity<Tkey>.Id))!.Equals(id)) ?? null;

        }

        public virtual async Task<T> Update(T entity)
        {
            var entry =_context.Set<T>().Update(entity);
            return entry.Entity;
        }

        public virtual async Task<int> save() 
        {
           return await _context.SaveChangesAsync();
        }
    }
}
