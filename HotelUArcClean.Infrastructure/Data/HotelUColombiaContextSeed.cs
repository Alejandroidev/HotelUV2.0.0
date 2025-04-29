using HotelUColombia.Data;
using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelUColombia.Data;

public class HotelUColombiaContextSeed
{
    /// <summary>
    /// Creado Por Alejandro Salcedo
    /// </summary>
    /// <param name="generalContext"></param>
    /// <param name="logger"></param>
    /// <param name="retry"></param>
    /// <returns></returns>
    public static async Task SeedAsync(HotelUColombiaContext generalContext,
        ILogger logger,
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {


        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(generalContext, logger, retryForAvailability);
            throw;
        }


    }

    public static IEnumerable<Booking> GetPreconfiguredBooking()
    {
        return new List<Booking>
            {
                new Booking
                {
                    IdCliente = 1,
                    IdRoom = 1,

                    IdStatus = 1,
                    ValorTotal = 120.000,
                    IdUsuario = 1,
                },
                new Booking
                {
                    IdCliente = 2,
                    IdRoom = 2,

                    IdStatus = 1,
                    ValorTotal = 160.000,
                    IdUsuario = 1,
                }
            };
    }

    public static IEnumerable<Rooms> GetPreconfiguredRooms()
    {
        return new List<Rooms>
            {
                new Rooms
                {
                    Id = 1,
                    Category= 1,
                    Bathroom = false,
                    Freezer = false,
                    TV = false,
                    NumberBeds=1,
                    Price = 80000,
                    Image = "images/Deluxe-1.jpg"
                },
                new Rooms
                {
                    Id = 2,
                    Category= 2,
                    Bathroom = false,
                    Freezer = false,
                    TV = true,
                    NumberBeds=2,
                    Price = 120000,
                    Image = "images/Deluxe-1.jpg"
                },
                new Rooms
                {
                    Id = 3,
                    Category= 3,
                    Bathroom = true,
                    Freezer = true,
                    TV = true,
                    NumberBeds=3,
                    Price = 200000,
                    Image = "images/Deluxe-1.jpg"
                },
                new Rooms
                {
                    Id = 4,
                    Category= 4,
                    Bathroom = true,
                    Freezer = true,
                    TV = true,
                    NumberBeds=4,
                    Price = 200000,
                    Image = "images/Deluxe-1.jpg"
                },
                new Rooms
                {
                    Id = 5,
                    Category= 5,
                    Bathroom = true,
                    Freezer = true,
                    TV = true,
                    NumberBeds=5,
                    Price = 200000,
                    Image = "images/Deluxe-1.jpg"
                },
                new Rooms
                {
                    Id = 6,
                    Category= 6,
                    Bathroom = true,
                    Freezer = true,
                    TV = true,
                    NumberBeds=6,
                    Price = 200000,
                    Image = "images/Deluxe-1.jpg"
                },
                new Rooms
                {
                    Id = 7,
                    Category= 7,
                    Bathroom = true,
                    Freezer = true,
                    TV = true,
                    NumberBeds=3,
                    Price = 200000,
                    Image = "images/Deluxe-1.jpg"
                },
                new Rooms
                {
                    Id = 8,
                    Category= 8,
                    Bathroom = true,
                    Freezer = true,
                    TV = true,
                    NumberBeds=3,
                    Price = 200000,
                    Image = "images/Deluxe-1.jpg"
                }
            };
    }

    public static IEnumerable<StatusBooking> GetPreconfiguredStatus()
    {
        return new List<StatusBooking>
            {
                new StatusBooking
                {
                    Status = "Reservado"
                },
                new StatusBooking
                {
                    Status = "Cancelado"
                },
                new StatusBooking
                {
                    Status = "En Uso"
                },
                new StatusBooking
                {
                    Status = "Facturado"
                },
                new StatusBooking
                {
                    Status = "Pagada"
                },
                new StatusBooking
                {
                    Status = "Auditada"
                }
            };
    }
    public static IEnumerable<User> GetPreconfiguredRoles()
    {
        return new List<User>
            {
                new User
                {
                    User_Name = "Alejo",
                    Comments = "Administrador",
                    Correo = "elasfranco@gmail.com",
                    LastName = "Salcedo",
                    Name = "Alejandro",
                    Rol = "Admin",
                    Password = "Password",
                    Id = 1  
                }
            };
    }





}
