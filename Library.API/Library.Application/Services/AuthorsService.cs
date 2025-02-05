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
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Create(Author author)
        {
            var authorId = await _unitOfWork.AuthorsRepository.Create(author);
            await _unitOfWork.SaveChangesAsync();
            return authorId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            return await _unitOfWork.AuthorsRepository.Delete(id);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _unitOfWork.AuthorsRepository.GetAll();
        }

        public async Task<List<Author>> GetById(Guid id)
        {
            return await _unitOfWork.AuthorsRepository.GetById(id);
        }

        public async Task<Guid> Update(Guid id, string name, string surname, DateOnly birthday, string country)
        {
            return await _unitOfWork.AuthorsRepository.Update(id, name, surname, birthday, country);
        }
    }
}
