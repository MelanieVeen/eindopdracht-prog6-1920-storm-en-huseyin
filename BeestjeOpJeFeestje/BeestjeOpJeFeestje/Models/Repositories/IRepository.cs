﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeestjeOpJeFeestje.Models.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int? ID);
        Task<List<T>> GetAll();
        Task<List<T>> Find(params int[] keyValues);
        Task Create(T type);
        Task Update(T type);
        Task Delete(T type);
        bool Exists(int? ID);
        bool Exists(T type);
    }
}