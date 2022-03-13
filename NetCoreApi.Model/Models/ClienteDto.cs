namespace NetCoreApi.Services.Models
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public short Disabled { get; set; }
    }
}
