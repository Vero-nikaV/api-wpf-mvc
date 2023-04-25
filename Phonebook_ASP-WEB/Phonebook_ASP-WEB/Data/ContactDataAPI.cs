using Newtonsoft.Json;
using Phonebook_ASP_WEB.Interfaces;
using Phonebook_ASP_WEB.Models;
using System.Text;

namespace Phonebook_ASP_WEB.Data
{
    public class ContactDataAPI : IContactData
    {
        private HttpClient httpClient { get; set; }
        public ContactDataAPI()
        {
            httpClient = new HttpClient();
        }
        public void AddContact(Contact contact)
        {
            string url = @"https://localhost:7037/api/contact";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
        public IEnumerable<Contact> GetContacts()
        {
            string url = @"https://localhost:7037/api/contact";

            string json = httpClient.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
        }
        public void DeleteContact(int id)
        {
            string url = $"https://localhost:7037/api/contact/{id}";

            var response = httpClient.DeleteAsync(requestUri: url).Result;

        }
        public Contact GetContact(int id)
        {
            string url = $"https://localhost:7037/api/contact/{id}";
            string json = httpClient.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Contact>(json);
        }
        public void UpdateContact(Contact contact)
        {
            string url = $"https://localhost:7037/api/contact/{contact.Id}";
            var response = httpClient.PutAsJsonAsync(url, contact);
        }

    }
}
