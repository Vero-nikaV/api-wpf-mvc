using Phonebook_ASP_API.Interfaces;
using Phonebook_ASP_API.Models;

namespace Phonebook_ASP_API.Data
{
    public class ContactRepository:IContactRepository
    {
        private DataContext dbContext;
        public ContactRepository(DataContext context)
        {
            dbContext = context;
        }
        public IEnumerable<Contact> Getcontacts()
        {
            return dbContext.Contacts;
        }

        public Contact GetContact(int Id)
        {

            return dbContext.Contacts.Find(Id);
        }

        public void CreateContact(Contact item)
        {
            dbContext.Contacts.Add(item);
            dbContext.SaveChanges();
        }
        public void UpdateContact(Contact updatedContact)
        {
            Contact currentItem = GetContact(updatedContact.Id);
            currentItem.Address = updatedContact.Address;
            currentItem.Phone = updatedContact.Phone;
            currentItem.Description = updatedContact.Description;
            currentItem.Patronimic = updatedContact.Patronimic;
            currentItem.Surname = updatedContact.Surname;
            currentItem.Name = updatedContact.Name;
            dbContext.Contacts.Update(currentItem);
            dbContext.SaveChanges();
        }

        public Contact DeleteContact(int Id)
        {
            Contact contact = GetContact(Id);
            if (contact != null)
            {
                dbContext.Contacts.Remove(contact);
                dbContext.SaveChanges();
            }
            return contact;
        }
    }
}

