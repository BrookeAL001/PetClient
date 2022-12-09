namespace PetClient.Models
{
    public class AddClientRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long phone { get; set; }
        public string Address { get; set; }
        public string PetName { get; set; }
        public string species { get; set; }
        public string breed { get; set; }

        public DateTime PetBirthday { get; set; }
    }
}
