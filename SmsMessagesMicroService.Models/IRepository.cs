﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmsMessagesMicroService.Models
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
