using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReservaHotel.Infrastructure.Persistence;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Seeding
{
    /// <summary>
    /// Class for seeding the database with default data.
    /// </summary>
    public static class HotelDbContextSeed
    {
        /// <summary>
        /// Seeds the database with default data.
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(HotelDbContext context)
        {
            context.Database.EnsureCreated();
            // Check if the database is empty

            AddStatusBookig(context);
            // Add default booking statuses if the database is empty

            AddTypeRoom(context);
            // Add default room types if the database is empty

            AddRooms(context);
            // Add default rooms if the database is empty

            AddClients(context);
            // Add default clients if the database is empty

            AddUsers(context);
            // Add default users if the database is empty

            AddBookings(context);
            // Add default bookings if the database is empty

            AddItineraries(context);
            // Add default itineraries if the database is empty
        }

        #region Private Methods
        /// <summary>
        /// Adds default itineraries to the database if they do not exist.
        /// </summary>
        /// <param name="context"></param>
        private static void AddItineraries(HotelDbContext context)
        {
            if (!context.Itinerary.Any())
            {
                context.Itinerary.AddRange(
                    new Itinerary
                    {
                        BookingId = 1,
                        CheckInDate = DateTime.Now.AddDays(1).ToUniversalTime(),
                        CheckOutDate = DateTime.Now.AddDays(3).ToUniversalTime()
                    },
                    new Itinerary
                    {
                        BookingId = 2,
                        CheckInDate = DateTime.Now.AddDays(2).ToUniversalTime(),
                        CheckOutDate = DateTime.Now.AddDays(4).ToUniversalTime()
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds default bookings to the database if they do not exist.
        /// </summary>
        /// <param name="context"></param>
        private static void AddBookings(HotelDbContext context)
        {
            if (!context.Booking.Any())
            {
                context.Booking.AddRange(
                    new Booking
                    {
                        ClientId = 1,
                        RoomId = 1,
                        StatusBookingId = 1,
                        SystemUserId = 1,
                        CreationDate = DateTime.Now.ToUniversalTime(),
                        StartDate = DateTime.Now.AddDays(1).ToUniversalTime(),
                        EndDate = DateTime.Now.AddDays(3).ToUniversalTime()
                    },
                    new Booking
                    {
                        ClientId = 2,
                        RoomId = 3,
                        StatusBookingId = 1,
                        SystemUserId = 3,
                        CreationDate = DateTime.Now.ToUniversalTime(),
                        StartDate = DateTime.Now.AddDays(4).ToUniversalTime(),
                        EndDate = DateTime.Now.AddDays(6).ToUniversalTime()
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds default users to the database if they do not exist.
        /// </summary>
        /// <param name="context"></param>
        private static void AddUsers(HotelDbContext context)
        {
            if (!context.SystemUser.Any())
            {
                context.SystemUser.AddRange(
                    new SystemUser
                    {
                        Username = "admin",
                        Role = "Administrador",
                        Email = "admin@example.com",
                        PasswordHash = "hashedpassword1"
                    },
                    new SystemUser
                    {
                        Username = "reception1",
                        Role = "Recepcionista",
                        Email = "reception1@example.com",
                        PasswordHash = "hashedpassword2"
                    },
                    new SystemUser
                    {
                        Username = "reception2",
                        Role = "Recepcionista",
                        Email = "reception2@example.com",
                        PasswordHash = "hashedpassword3"
                    },
                    new SystemUser
                    {
                        Username = "manager",
                        Role = "Gerente",
                        Email = "manager@example.com",
                        PasswordHash = "hashedpassword4"
                    },
                    new SystemUser
                    {
                        Username = "cleaning",
                        Role = "Limpieza",
                        Email = "cleaning@example.com",
                        PasswordHash = "hashedpassword5"
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds default clients to the database if they do not exist.
        /// </summary>
        /// <param name="context"></param>
        private static void AddClients(HotelDbContext context)
        {
            if (!context.Clients.Any())
            {
                context.Clients.AddRange(
                    new Client
                    {
                        FirstName = "Juan",
                        LastName = "Pérez",
                        Email = "juan.perez@example.com",
                        Phone = "123456789",
                        DocumentNumber = "12345678"
                    },
                    new Client
                    {
                        FirstName = "María",
                        LastName = "Gómez",
                        Email = "maria.gomez@example.com",
                        Phone = "987654321",
                        DocumentNumber = "87654321"
                    },
                    new Client
                    {
                        FirstName = "Carlos",
                        LastName = "López",
                        Email = "carlos.lopez@example.com",
                        Phone = "456789123",
                        DocumentNumber = "45678912"
                    },
                    new Client
                    {
                        FirstName = "Ana",
                        LastName = "Martínez",
                        Email = "ana.martinez@example.com",
                        Phone = "789123456",
                        DocumentNumber = "78912345"
                    },
                    new Client
                    {
                        FirstName = "Luis",
                        LastName = "Ramírez",
                        Email = "luis.ramirez@example.com",
                        Phone = "321654987",
                        DocumentNumber = "32165498"
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds default rooms to the database if they do not exist.
        /// </summary>
        /// <param name="context"></param>
        private static void AddRooms(HotelDbContext context)
        {
            if (!context.Room.Any())
            {
                context.Room.AddRange(
                    new Room
                    {
                        Number = "101",
                        Floor = 1,
                        Price = 80000,
                        Capacity = 1,
                        RoomTypeId = 1
                    },
                    new Room
                    {
                        Number = "102",
                        Floor = 1,
                        Price = 125000,
                        Capacity = 2,
                        RoomTypeId = 2
                    },
                    new Room
                    {
                        Number = "201",
                        Floor = 2,
                        Price = 150000,
                        Capacity = 2,
                        RoomTypeId = 3
                    },
                    new Room
                    {
                        Number = "202",
                        Floor = 2,
                        Price = 200000,
                        Capacity = 4,
                        RoomTypeId = 4
                    },
                    new Room
                    {
                        Number = "301",
                        Floor = 3,
                        Price = 300000,
                        Capacity = 1,
                        RoomTypeId = 5
                    }
                );
                context.SaveChanges();
            }
        }
       
        /// <summary>
        /// Adds default booking statuses to the database if they do not exist.
        /// </summary>
        /// <param name="context"></param>
        private static void AddStatusBookig(HotelDbContext context)
        {
            if (!context.StatusBooking.Any())
            {
                context.StatusBooking.AddRange(
                    new StatusBooking
                    {
                        StatusName = "Pendiente"
                    },
                    new StatusBooking
                    {
                        StatusName = "Confirmada"
                    },
                    new StatusBooking
                    {
                        StatusName = "Cancelada"
                    },
                    new StatusBooking
                    {
                        StatusName = "En Proceso"
                    },
                    new StatusBooking
                    {
                        StatusName = "Finalizada"
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds default room types to the database if they do not exist.
        /// </summary>
        /// <param name="context"></param>
        private static void AddTypeRoom(HotelDbContext context)
        {
            if (!context.TypeRoom.Any())
            {
                context.TypeRoom.AddRange(
                    new TypeRoom
                    {
                        TypeName = "Individual",
                        Description = "Habitación para una persona"
                    },
                    new TypeRoom
                    {
                        TypeName = "Doble",
                        Description = "Habitación para dos personas"
                    },
                    new TypeRoom
                    {
                        TypeName = "Suite",
                        Description = "Habitación de lujo"
                    },
                    new TypeRoom
                    {
                        TypeName = "Familiar",
                        Description = "Habitación para familias"
                    },
                    new TypeRoom
                    {
                        TypeName = "Económica",
                        Description = "Habitación económica"
                    }
                );
                context.SaveChanges();
            }
        }


        #endregion
    }
}