namespace deportesApi.Dtos
{
    public class DeporteDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
