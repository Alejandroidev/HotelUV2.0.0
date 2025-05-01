namespace ReservaHotel.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Documento { get; set; } = null!;

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
