using ContactBookApp.Data_Access.DataContext;
using ContactBookApp.Data_Access.Interfaces;
using ContactBookApp.Domain.DTOs;
using ContactBookApp.Domain.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookApp.Data_Access.Repositories
{
    public class ContactRepository : IContactRepository
    {
        
        public async Task<Contact> AddContact(ContactCreateDTO contact)
        {
            using (var context = new ContactBookContext())
            {
                try
                {
                    var existingContact = await context.Contacts.AnyAsync(x => x.Name == contact.Name);
                    if (existingContact)
                    {
                        throw new Exception($"Contact already exists");
                    }
                    var newContact = new Contact()
                    {
                        Name = contact.Name,
                        PhoneNumber = contact.PhoneNumber,
                        Email = contact.Email,
                        Address = contact.Address
                        
                    };
                   await context.Contacts.AddAsync(newContact);
                    await context.SaveChangesAsync();

                    return newContact;
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}\n\n{ex.Source}");
                }
            }
            
        }

        public async Task<List<Contact>> GetAll()
        {
            using (var database = new ContactBookContext())
            {
                var contacts = await database.Contacts.ToListAsync();
                if(contacts == null)
                {
                    throw new ArgumentNullException();
                }
                return contacts;
                
            }
        }

        public Task<Contact> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContact(int id, Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
