using Library.Domain.Abstractions;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<Guid> Create(Author author)
        {
            return await _authorsRepository.Create(author);
        }

        public async Task<Guid> Delete(Guid id)
        {
            return await _authorsRepository.Delete(id);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _authorsRepository.GetAll();
        }

        public async Task<List<Author>> GetById(Guid id)
        {
            return await _authorsRepository.GetById(id);
        }

        public async Task<Guid> Update(Guid id, string name, string surname, DateOnly birthday, string country)
        {
            return await _authorsRepository.Update(id, name, surname, birthday, country);
        }
    }
}
