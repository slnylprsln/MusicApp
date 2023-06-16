﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T? Get(int id);
        Task<T?> GetAsync(int id);

        IList<T?> GetAll();
        Task<IList<T?>> GetAllAsync();

        IList<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);

        Task<bool> IsExistsAsync(int id);
    }
}
