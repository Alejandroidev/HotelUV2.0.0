using AutoMapper;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Application.Config
{
    /// <summary>
    /// Automapper mapping profile
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Creates a mapping configuration from the Tsource type to the TDestination type
        /// </summary>
        /// return Mapping expression for more configurations options 
        public MappingProfile()
        {
            #region hotel
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Itinerary, ItineraryDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<StatusBooking, StatusBookingDto>().ReverseMap();
            CreateMap<SystemUser, SystemUserDto>().ReverseMap();
            CreateMap<TypeRoom, TypeRoomDto>().ReverseMap();
            CreateMap<Amenity, AmenityDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemDto>().ReverseMap();
            CreateMap<CustomerInteraction, CustomerInteractionDto>().ReverseMap();
            CreateMap<PqrCase, PqrCaseDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            #endregion
        }
    }
}