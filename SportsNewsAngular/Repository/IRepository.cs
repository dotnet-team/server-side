using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsNewsAngular.Models;

namespace SportsNewsAngular.Repository
{
    public interface IRepository
    {
        Task<List<T>> FindAll<T>() where T : Entity;
        Task<T> FindById<T>(int id) where T : Entity;
        Task CreateAsync<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        Task DeleteAsync<T>(T entity) where T : Entity;
    }
}
