using AutoMapper;
using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities.Hotel;


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
            #region Billing
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Itinerary, ItineraryDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<StatusBooking, StatusBookingDto>().ReverseMap();
            CreateMap<SystemUser, SystemUserDto>().ReverseMap();
            CreateMap<TypeRoom, TypeRoomDto>().ReverseMap();
            #endregion
        }
    }
}