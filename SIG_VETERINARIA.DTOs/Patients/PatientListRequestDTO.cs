namespace SIG_VETERINARIA.DTOs.Patients
{
    public class PatientListRequestDTO
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int client_id { get; set; }
    }
}
