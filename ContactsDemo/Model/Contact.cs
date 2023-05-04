namespace ContactsDemo.Model
{
    public class Contact
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public Contact()
        {
        }

        public Contact(string id, string firstName, string email)
        {
            Id = id;
            FirstName = firstName;
            Email = email;
        }
    }
}
