namespace SIG_VETERINARIA.DTOs.Exams
{
    public class ExamListRequestDTO
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int consult_id { get; set; }
    }
}
