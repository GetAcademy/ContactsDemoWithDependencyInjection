using ContactsDemo.Model;

namespace ContactsDemoWithDependencyInjection
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Create(Contact contact)
        {
            var contacts = _contactRepository.GetAll();
            contacts.Add(contact);
            _contactRepository.SaveAll(contacts);
        }

        public List<Contact> Read()
        {
            return _contactRepository.GetAll();
        }

        public void Update(Contact changedContact)
        {
            var contacts = _contactRepository.GetAll();
            var contact = contacts.Find(c => c.Id == changedContact.Id);
            contact.FirstName = changedContact.FirstName;
            contact.Email = changedContact.Email;
            _contactRepository.SaveAll(contacts);
        }

        public void Delete(string id)
        {
            var contacts = _contactRepository.GetAll();
            var index = contacts.FindIndex(c => c.Id == id);
            if (index == -1) return;
            contacts.RemoveAt(index);
            _contactRepository.SaveAll(contacts);
        }
    }
}
