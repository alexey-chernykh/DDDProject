﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDbRepository<T> where T : class, IDbEntity
    {
        IQueryable<T> AllItems { get; }
        Task<List<T>> ToListAsync();
        Task<bool> AddItemAsync(T item);
        Task<T> GetItemAsync(Guid id);
        Task<bool> GhangeItemAsync(T item);
        Task<bool> DeleteItemAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}