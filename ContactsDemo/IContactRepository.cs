using ContactsDemo.Model;

namespace ContactsDemoWithDependencyInjection
{
    public interface IContactRepository
    {
        List<Contact> GetAll();

        void SaveAll(List<Contact> contacts);
    }
}
