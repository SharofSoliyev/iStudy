﻿using iStudy.Core.Entities.Base;
using iStudy.Core.Repository;
using iStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace iStudy.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDataContext _dbContext;

        private const int PAGE_COUNT = 20;

        public Repository(AppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Entry(entity).Property("CreatedDate").CurrentValue = DateTime.UtcNow;
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).Property("LastUpdatedDate").CurrentValue = DateTime.UtcNow;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }



        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdIncAsync(int id, string[] includeTables = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            return await query.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            query = query.Where(predicate);
            return orderBy(query);
        }

        public IQueryable<T> GetAllByInc(string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            return query;
        }

        public IQueryable<T> GetAllByExpInc(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            return query.Where(predicate);
        }

        public IQueryable<T> GetAllByExp(Expression<Func<T, bool>> predicate, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query.Where(predicate);
        }

        public IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            query = query.Where(predicate);
            return orderBy(query);
        }

        public IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            query = query.Where(predicate);

            if (page > 1) query = query.Skip(page * PAGE_COUNT);

            query = query.Take(PAGE_COUNT);

            return orderBy(query);
        }

        public IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            query = query.Where(predicate);

            if (page > 1) query = query.Skip(page * PAGE_COUNT);

            query = query.Take(PAGE_COUNT);

            return orderBy(query);
        }

        public IQueryable<T> GetAll(bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public IQueryable<T> GetAllByPage(int page, int limit, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            query = query.Where(predicate);

            if (page > 1) query = query.Skip((page - 1) * limit);

            query = query.Take(limit);

            return orderBy(query);
        }

    }
}
