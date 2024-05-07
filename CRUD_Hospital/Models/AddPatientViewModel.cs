namespace CRUD_Hospital.Models
{
    public class AddPatientViewModel
    {
        public string? PatientName { get; set; }

        public string? Address { get; set; }

        public long Mobile { get; set; }

        public DateTime RegistrationDate { get; set; } 
    }
}
