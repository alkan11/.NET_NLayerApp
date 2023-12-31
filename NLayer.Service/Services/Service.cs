﻿using Microsoft.EntityFrameworkCore;
using NLayer.Service.Excaption;
using NlayerCoreApp.Repositories;
using NlayerCoreApp.Service;
using NlayerCoreApp.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitofwork;

        public Service(IUnitOfWork unitofwork, IGenericRepository<T> repository)
        {
            _unitofwork = unitofwork;
            _repository = repository;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitofwork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task DeleteAsync(T entity)
        {
           _repository.Remove(entity);
            await _unitofwork.CommitAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitofwork.CommitAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAync(int id)
        {
            var hasProduct= await _repository.GetByIdAsync(id);
            if (hasProduct == null)
            {
                throw new ClientSideException($"{typeof(T).Name}");
            }
            return hasProduct;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitofwork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitofwork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
