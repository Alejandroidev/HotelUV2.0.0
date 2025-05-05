using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto
{
    public class ClientDto : IDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Documento { get; set; } = null!;

    }
}
