namespace NetCoreApi.Services.Models
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public short Disabled { get; set; }
    }
}
