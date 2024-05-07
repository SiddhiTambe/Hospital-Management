namespace CRUD_Hospital.Models
{
    public class UpdatePatientViewModel
    {
        public Guid Id { get; set; }
        public string? PatientName { get; set; }
        public String? Address { get; set; }
        public long Mobile { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
