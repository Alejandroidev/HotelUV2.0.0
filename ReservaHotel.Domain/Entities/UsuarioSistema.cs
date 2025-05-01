namespace ReservaHotel.Domain.Entities;
public class UsuarioSistema
{
    public int IdUsuarioSistema { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ClaveHash { get; set; } = null!;

    public ICollection<Reserva> ReservasRegistradas { get; set; } = new List<Reserva>();
}