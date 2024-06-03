using ContactBookApp.Domain.DTOs;
using ContactBookApp.Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookApp.Data_Access.Interfaces
{
    internal interface IContactRepository
    {
        Task<Contact> AddContact(ContactCreateDTO contact);
        Task<bool> UpdateContact(int id, Contact contact);
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task<bool> RemoveContact(int id);

    }
}
