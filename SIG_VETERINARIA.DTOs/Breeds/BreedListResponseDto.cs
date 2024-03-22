namespace SIG_VETERINARIA.DTOs.Breeds
{
    public class BreedListResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int status { get; set; }
        public int specie_id { get; set; }
        public string specie { get; set; }
        public int totalRegisters { get; set; }
    }
}
