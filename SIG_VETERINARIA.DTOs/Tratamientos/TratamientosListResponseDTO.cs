﻿namespace SIG_VETERINARIA.DTOs.Tratamientos
{
    public class TratamientosListResponseDTO
    {
        public int id { get; set; }
        public string detalle { get; set; }
        public int diagnostico_id { get; set; }
        public int totalRecords { get; set; }
    }
}
