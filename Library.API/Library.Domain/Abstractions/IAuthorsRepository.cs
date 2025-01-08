﻿using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public interface IAuthorsRepository
    {
        Task<List<Author>> GetAll();
        Task<Guid> Create(Author author);
        Task<Guid> Update(Guid id, string name, string surname, DateOnly birthday);
        Task<Guid> Delete(Guid id);
    }
}
