using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities.Hotel;
public class SystemUser : BaseEntity<int>, IAggregateRoot
{
    public int IdUsuarioSistema { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ClaveHash { get; set; } = null!;

    public ICollection<Booking> ReservasRegistradas { get; set; } = new List<Booking>();
}