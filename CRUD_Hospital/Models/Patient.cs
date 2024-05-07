namespace CRUD_Hospital.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public long Mobile { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
