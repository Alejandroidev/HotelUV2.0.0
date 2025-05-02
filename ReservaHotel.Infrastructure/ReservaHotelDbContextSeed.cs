using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReservaHotel.Infrastructure.Persistence;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Seeding
{
    public static class ReservaHotelDbContextSeed
    {
        public static void Seed(ReservaHotelDbContext context)
        {
            // Asegúrate de que la base de datos está creada
            context.Database.EnsureCreated();

            // EstadoReserva
            if (!context.EstadoReserva.Any())
            {
                context.EstadoReserva.AddRange(
                    new EstadoReserva { NombreEstado = "Pendiente" },
                    new EstadoReserva { NombreEstado = "Confirmada" },
                    new EstadoReserva { NombreEstado = "Cancelada" },
                    new EstadoReserva { NombreEstado = "En Proceso" },
                    new EstadoReserva { NombreEstado = "Finalizada" }
                );
                context.SaveChanges();
            }

            // TipoHabitacion
            if (!context.TipoHabitacion.Any())
            {
                context.TipoHabitacion.AddRange(
                    new TipoHabitacion { NombreTipo = "Individual", Descripcion = "Habitación para una persona" },
                    new TipoHabitacion { NombreTipo = "Doble", Descripcion = "Habitación para dos personas" },
                    new TipoHabitacion { NombreTipo = "Suite", Descripcion = "Habitación de lujo" },
                    new TipoHabitacion { NombreTipo = "Familiar", Descripcion = "Habitación para familias" },
                    new TipoHabitacion { NombreTipo = "Económica", Descripcion = "Habitación económica" }
                );
                context.SaveChanges();
            }

            // Habitacion
            if (!context.Habitacion.Any())
            {
                context.Habitacion.AddRange(
                    new Habitacion { Numero = "101", Piso = 1, Precio = 50.00m, Capacidad = 1, IdTipoHabitacion = 1 },
                    new Habitacion { Numero = "102", Piso = 1, Precio = 75.00m, Capacidad = 2, IdTipoHabitacion = 2 },
                    new Habitacion { Numero = "201", Piso = 2, Precio = 150.00m, Capacidad = 2, IdTipoHabitacion = 3 },
                    new Habitacion { Numero = "202", Piso = 2, Precio = 200.00m, Capacidad = 4, IdTipoHabitacion = 4 },
                    new Habitacion { Numero = "301", Piso = 3, Precio = 30.00m, Capacidad = 1, IdTipoHabitacion = 5 }
                );
                context.SaveChanges();
            }

            // Cliente
            if (!context.Clientes.Any())
            {
                context.Clientes.AddRange(
                    new Cliente { Nombre = "Juan", Apellido = "Pérez", Email = "juan.perez@example.com", Telefono = "123456789", Documento = "12345678" },
                    new Cliente { Nombre = "María", Apellido = "Gómez", Email = "maria.gomez@example.com", Telefono = "987654321", Documento = "87654321" },
                    new Cliente { Nombre = "Carlos", Apellido = "López", Email = "carlos.lopez@example.com", Telefono = "456789123", Documento = "45678912" },
                    new Cliente { Nombre = "Ana", Apellido = "Martínez", Email = "ana.martinez@example.com", Telefono = "789123456", Documento = "78912345" },
                    new Cliente { Nombre = "Luis", Apellido = "Ramírez", Email = "luis.ramirez@example.com", Telefono = "321654987", Documento = "32165498" }
                );
                context.SaveChanges();
            }

            // UsuarioSistema
            if (!context.Usuarios.Any())
            {
                context.Usuarios.AddRange(
                    new UsuarioSistema { NombreUsuario = "admin", Rol = "Administrador", Email = "admin@example.com", ClaveHash = "hashedpassword1" },
                    new UsuarioSistema { NombreUsuario = "reception1", Rol = "Recepcionista", Email = "reception1@example.com", ClaveHash = "hashedpassword2" },
                    new UsuarioSistema { NombreUsuario = "reception2", Rol = "Recepcionista", Email = "reception2@example.com", ClaveHash = "hashedpassword3" },
                    new UsuarioSistema { NombreUsuario = "manager", Rol = "Gerente", Email = "manager@example.com", ClaveHash = "hashedpassword4" },
                    new UsuarioSistema { NombreUsuario = "cleaning", Rol = "Limpieza", Email = "cleaning@example.com", ClaveHash = "hashedpassword5" }
                );
                context.SaveChanges();
            }

            // Reserva
            if (!context.Reservas.Any())
            {
                context.Reservas.AddRange(
                    new Reserva
                    {
                        IdCliente = 1,
                        IdHabitacion = 1,
                        IdEstadoReserva = 1,
                        IdUsuarioSistema = 1,
                        FechaCreacion = DateTime.Now.ToUniversalTime(),
                        FechaInicio = DateTime.Now.AddDays(1).ToUniversalTime(),
                        FechaFin = DateTime.Now.AddDays(3).ToUniversalTime()
                    },
                    new Reserva
                    {
                        IdCliente = 2,
                        IdHabitacion = 2,
                        IdEstadoReserva = 2,
                        IdUsuarioSistema = 2,
                        FechaCreacion = DateTime.Now.ToUniversalTime(),
                        FechaInicio = DateTime.Now.AddDays(2).ToUniversalTime(),
                        FechaFin = DateTime.Now.AddDays(4).ToUniversalTime()
                    }
                );
                context.SaveChanges();
            }

            // Itinerario
            if (!context.Itinerarios.Any())
            {
                context.Itinerarios.AddRange(
                    new Itinerario
                    {
                        IdReserva = 1,
                        FechaEntrada = DateTime.Now.AddDays(1).ToUniversalTime(),
                        FechaSalida = DateTime.Now.AddDays(3).ToUniversalTime()
                    },
                    new Itinerario
                    {
                        IdReserva = 2,
                        FechaEntrada = DateTime.Now.AddDays(2).ToUniversalTime(),
                        FechaSalida = DateTime.Now.AddDays(4).ToUniversalTime()
                    }
                );
                context.SaveChanges();
            }
        }
    }
}