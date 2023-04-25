using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_WPF
{
    /// <summary>
    /// Логика взаимодействия с API
    /// </summary>
    internal class DataApi
    {
        private HttpClient httpClient { get; set; }

        public DataApi()
        {
            httpClient = new HttpClient();
        }
        /// <summary>
        /// Добавление контакта
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(Contact contact)
        {
            string url = @"https://localhost:7037/api/contact";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
        /// <summary>
        /// Получение всех контактов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetContacts()
        {
            string url = @"https://localhost:7037/api/contact";

            string json = httpClient.GetStringAsync(url).Result;
            Console.WriteLine(json);
            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);

        }
    }
}
