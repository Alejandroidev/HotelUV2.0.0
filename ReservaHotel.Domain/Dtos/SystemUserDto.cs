using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;
public class SystemUserDto : IDto
{
    public int IdUsuarioSistema { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ClaveHash { get; set; } = null!;

    public ICollection<BookingDto> ReservasRegistradas { get; set; } = new List<BookingDto>();
}