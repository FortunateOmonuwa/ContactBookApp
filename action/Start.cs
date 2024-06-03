using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBookApp.Data_Access.Repositories;
using ContactBookApp.Domain.DTOs;
using ContactBookApp.Domain.model;


namespace ContactBookApp.action
{
    internal class Start
    {

        public static void Run()
        {
            ContactRepository contactBook = new ContactRepository();
            bool running = true;

            while (running)
            {

                Console.WriteLine("1. Add Contact.");
                Console.WriteLine("2. Remove Contact.");
                Console.WriteLine("3. Get a Contact.");
                Console.WriteLine("4. Display all Contact.");
                Console.WriteLine("5. Exit");

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("-----------------------------------------");

                string userInput = Console.ReadLine();
                Start.InputValidator(userInput);

                switch (userInput)
                {
                    case "1":
                        //Enter your name
                        Console.WriteLine("Enter name : ");
                        string name = Console.ReadLine();
                      //  Start.InputValidator(name);

                        //Enter phone number
                        Console.WriteLine("Enter Phone number : ");
                        string phoneNumber = Console.ReadLine(); 
                    Console.WriteLine("Enter Phone number : ");
                        string email = Console.ReadLine(); 
                    Console.WriteLine("Enter Phone number : ");
                        string address = Console.ReadLine();
                    //   Start.InputValidator(phoneNumber);
                    //  Start.PhoneNumberValidator(phoneNumber);

                    //Add contact to the Dictionarry
                    ContactCreateDTO newContact = new ContactCreateDTO()
                    {
                        Name = name,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        Address = address
                    };
                    
                        var addedContact = contactBook.AddContact(newContact);
                        Console.WriteLine($"Contact added sucessfully.\n\n{addedContact.Result.Id}\n{addedContact.Result.Name}\n{addedContact.Result.Email}\n{addedContact.Result.Address}");
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("-----------------------------------------");
                        break;

                    case "2":
                        Console.WriteLine("Enter the contact ID: ");
                        int contactId = int.Parse(Console.ReadLine());
                       // Start.InputValidator(nametoRemove);
                        contactBook.RemoveContact(contactId);
                        Console.WriteLine("Contact deleted sucessfully.");
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("-----------------------------------------");
                        break;

                    case "3":
                        Console.WriteLine("Enter Contact ID : ");
                    int contact_Id = int.Parse(Console.ReadLine());
                    // Start.InputValidator(nameOfContact);
                    //var specificContact = contactBook.GetById(contact_Id);
                    //Console.WriteLine($"Here you go.\n\n{specificContact.Result.Id}\n{addedContact.Result.Name}\n{addedContact.Result.Email}\n{addedContact.Result.Address}");
                    Console.WriteLine($"Contact available");
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("-----------------------------------------");
                        break;
                    case "4":
                       
                        var allContacts = contactBook.GetAll();
                    foreach(var contact in allContacts.Result)
                    {
                        Console.WriteLine($"Here you go.\n\n{contact.Id}\n{contact.Name}\n{contact.Email}\n{contact.Address}");
                    }
                     Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("-----------------------------------------");
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input,pls try again");
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("-----------------------------------------");
                        break;

                }

            }
        }

        static string InputValidator(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Input field is required");
                return Console.ReadLine();
            }
        }
        static string PhoneNumberValidator(string input)
        {
            if (input.Length == 11 )
            {
                return input;
            }
            else
            {
                Console.WriteLine("Phone number is incorrect,Pls retry");
                return Console.ReadLine();
            }
        }

    }
}
