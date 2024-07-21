using deportesApi.models;

namespace deportesApi.Dtos
{
    public class SocioDto
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string nombreDeporte { get; set; }
        public DateTime? FechaAlta { get; set; }

    }
}
