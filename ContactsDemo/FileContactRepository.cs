using ContactsDemo.Model;
using System.Text.Json;

namespace ContactsDemoWithDependencyInjection
{
    public class FileContactRepository : IContactRepository
    {
        public List<Contact> GetAll()
        {
            if (!File.Exists("contacts.json")) return new List<Contact>();
            var json = File.ReadAllText("contacts.json");
            return JsonSerializer.Deserialize<List<Contact>>(json);

        }

        public void SaveAll(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts);
            File.WriteAllText("contacts.json", json);
        }
    }
}
