namespace ContactsWebApp.Models
{
    public class AddContactRequestDTO
    {
        // We did not copy the Id from ContactM We don't want angular app send the id the api will create it
        public required string Name { get; set; }

        public string? Email { get; set; }

        public required string PhoneNumber { get; set; }

        public bool Favorite { get; set; }
    }
}
