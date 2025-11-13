using Microsoft.EntityFrameworkCore;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace ReservaHotel.Infrastructure.Data
{
    public static class HotelDbContextSeed
    {
        public static async Task SeedAsync(HotelDbContext context)
        {
            await SeedLocationsAsync(context);
            await SeedAmenitiesAsync(context);
            await SeedStatusAndTypesAsync(context);
            await SeedRoomsAndAmenitiesAsync(context);
            await SeedClientsAsync(context);
            await SeedEmployeesAndUsersAsync(context);
            await SeedBookingsAndRelatedAsync(context);
            await SeedCrmAndPqrAsync(context);
        }

        private static async Task SeedLocationsAsync(HotelDbContext context)
        {
            if (!await context.Locations.AnyAsync())
            {
                await context.Locations.AddRangeAsync(
                    new Location { Name = "Bogotá", Address = "Av. El Dorado #123" },
                    new Location { Name = "Medellín", Address = "Cra. 43A #7-50, El Poblado" }
                );
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedAmenitiesAsync(HotelDbContext context)
        {
            if (!await context.Amenities.AnyAsync())
            {
                await context.Amenities.AddRangeAsync(
                    new Amenity { Name = "Wi-Fi", Description = "High-speed internet access" },
                    new Amenity { Name = "Air Conditioning", Description = "Climate control" },
                    new Amenity { Name = "Pool", Description = "Outdoor swimming pool" },
                    new Amenity { Name = "Gym", Description = "Fitness center access" }
                );
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedStatusAndTypesAsync(HotelDbContext context)
        {
            if (!await context.StatusBookings.AnyAsync())
            {
                await context.StatusBookings.AddRangeAsync(
                    new StatusBooking { StatusName = "Confirmed" },
                    new StatusBooking { StatusName = "Pending" },
                    new StatusBooking { StatusName = "Cancelled" }
                );
            }

            if (!await context.TypeRooms.AnyAsync())
            {
                await context.TypeRooms.AddRangeAsync(
                    new TypeRoom { Name = "Standard", Description = "A standard room for one or two guests." },
                    new TypeRoom { Name = "Suite", Description = "A luxurious suite with extra space." },
                    new TypeRoom { Name = "Family", Description = "A room designed for families." }
                );
            }
            await context.SaveChangesAsync();
        }

        private static async Task SeedRoomsAndAmenitiesAsync(HotelDbContext context)
        {
            if (!await context.Rooms.AnyAsync())
            {
                var locationBogota = await context.Locations.FirstAsync(l => l.Name == "Bogotá");
                var locationMedellin = await context.Locations.FirstAsync(l => l.Name == "Medellín");
                var typeStandard = await context.TypeRooms.FirstAsync(t => t.Name == "Standard");
                var typeSuite = await context.TypeRooms.FirstAsync(t => t.Name == "Suite");

                var rooms = new List<Room>
                {
                    new Room { Name = "101", Description = "Standard room with a city view.", Price = 150000, Capacity = 2, Status = RoomStatus.Available, IsFeatured = true, TypeRoomId = typeStandard.Id, LocationId = locationBogota.Id },
                    new Room { Name = "102", Description = "Standard room, quiet area.", Price = 160000, Capacity = 2, Status = RoomStatus.Cleaning, IsFeatured = false, TypeRoomId = typeStandard.Id, LocationId = locationBogota.Id },
                    new Room { Name = "201", Description = "Luxury suite with a balcony.", Price = 350000, Capacity = 3, Status = RoomStatus.Available, IsFeatured = true, TypeRoomId = typeSuite.Id, LocationId = locationMedellin.Id }
                };
                await context.Rooms.AddRangeAsync(rooms);
                await context.SaveChangesAsync();

                // Seed Room Amenities
                var wifi = await context.Amenities.FirstAsync(a => a.Name == "Wi-Fi");
                var ac = await context.Amenities.FirstAsync(a => a.Name == "Air Conditioning");
                var pool = await context.Amenities.FirstAsync(a => a.Name == "Pool");

                await context.RoomAmenities.AddRangeAsync(
                    new RoomAmenity { RoomId = rooms[0].Id, AmenityId = wifi.Id },
                    new RoomAmenity { RoomId = rooms[0].Id, AmenityId = ac.Id },
                    new RoomAmenity { RoomId = rooms[1].Id, AmenityId = wifi.Id },
                    new RoomAmenity { RoomId = rooms[2].Id, AmenityId = wifi.Id },
                    new RoomAmenity { RoomId = rooms[2].Id, AmenityId = ac.Id },
                    new RoomAmenity { RoomId = rooms[2].Id, AmenityId = pool.Id }
                );
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedClientsAsync(HotelDbContext context)
        {
            if (!await context.Clients.AnyAsync())
            {
                await context.Clients.AddRangeAsync(
                    new Client { Name = "Carlos", LastName = "Rodriguez", Email = "carlos.r@example.com", PhoneNumber = "3101234567" },
                    new Client { Name = "Ana", LastName = "Gomez", Email = "ana.g@example.com", PhoneNumber = "3209876543" }
                );
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedEmployeesAndUsersAsync(HotelDbContext context)
        {
            if (!await context.Employees.AnyAsync())
            {
                var locationBogota = await context.Locations.FirstAsync(l => l.Name == "Bogotá");
                var locationMedellin = await context.Locations.FirstAsync(l => l.Name == "Medellín");

                // Employee with user account
                var employeeAdmin = new Employee { FirstName = "Admin", LastName = "User", NationalId = "1000000001", Position = "System Administrator", Department = "IT", HireDate = DateTime.UtcNow.AddYears(-2), Email = "admin@hotel.com", PhoneNumber = "3001112233", LocationId = locationBogota.Id };
                CreatePasswordHash("Password123!", out byte[] adminHash, out byte[] adminSalt);
                var userAdmin = new User { Username = "admin", IsActive = true, PasswordHash = adminHash, PasswordSalt = adminSalt, Employee = employeeAdmin };

                // Employee without user account
                var employeeHousekeeping = new Employee { FirstName = "Maria", LastName = "Lopez", NationalId = "1000000002", Position = "Housekeeper", Department = "Housekeeping", HireDate = DateTime.UtcNow.AddMonths(-6), Email = "maria.l@hotel.com", PhoneNumber = "3004445566", LocationId = locationMedellin.Id };

                await context.Users.AddAsync(userAdmin);
                await context.Employees.AddAsync(employeeHousekeeping);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedBookingsAndRelatedAsync(HotelDbContext context)
        {
            if (!await context.Bookings.AnyAsync())
            {
                var clientCarlos = await context.Clients.FirstAsync(c => c.Email == "carlos.r@example.com");
                var room101 = await context.Rooms.FirstAsync(r => r.Name == "101");
                var statusConfirmed = await context.StatusBookings.FirstAsync(s => s.StatusName == "Confirmed");

                var booking = new Booking
                {
                    CheckInDate = DateTime.UtcNow.AddDays(10),
                    CheckOutDate = DateTime.UtcNow.AddDays(15),
                    NumberOfGuests = 2,
                    TotalPrice = room101.Price * 5,
                    ClientId = clientCarlos.Id,
                    RoomId = room101.Id,
                    StatusBookingId = statusConfirmed.Id
                };

                var itinerary = new Itinerary
                {
                    Booking = booking,
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate
                };

                var invoice = new Invoice
                {
                    Booking = booking,
                    Cufe = Guid.NewGuid().ToString(), 
                    IssueDate = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(30),
                    Subtotal = booking.TotalPrice,
                    TaxAmount = booking.TotalPrice * 0.19m, 
                    TotalAmount = booking.TotalPrice * 1.19m,
                    Status = InvoiceStatus.Issued
                };

                var invoiceItem = new InvoiceItem { Invoice = invoice, Description = $"Stay in Room {room101.Name}", Quantity = 5, UnitPrice = room101.Price, Total = booking.TotalPrice };

                await context.Bookings.AddAsync(booking);
                await context.Itineraries.AddAsync(itinerary);
                await context.Invoices.AddAsync(invoice);
                await context.InvoiceItems.AddAsync(invoiceItem);

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedCrmAndPqrAsync(HotelDbContext context)
        {
            if (!await context.CustomerInteractions.AnyAsync())
            {
                var clientAna = await context.Clients.FirstAsync(c => c.Email == "ana.g@example.com");
                var adminUser = await context.Users.FirstAsync(u => u.Username == "admin");

                await context.CustomerInteractions.AddAsync(
                    new CustomerInteraction { ClientId = clientAna.Id, InteractionDate = DateTime.UtcNow.AddDays(-5), InteractionType = InteractionType.PhoneCall, Notes = "Client called to ask about pool hours.", SystemUserId = adminUser.Id }
                );
            }

            if (!await context.PqrCases.AnyAsync())
            {
                var clientCarlos = await context.Clients.FirstAsync(c => c.Email == "carlos.r@example.com");
                var booking = await context.Bookings.FirstAsync(b => b.ClientId == clientCarlos.Id);

                await context.PqrCases.AddAsync(
                    new PqrCase { ClientId = clientCarlos.Id, BookingId = booking.Id, PqrType = PqrType.Petition, Status = PqrStatus.Open, Subject = "Late check-out request", Description = "Requesting a late check-out until 2 PM.", CreatedAt = DateTime.UtcNow.AddDays(-1) }
                );
            }
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a password hash and salt from a given password.
        /// </summary>
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}