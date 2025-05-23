﻿using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Dto;

namespace ReservaHotel.Application.Interfaces
{
    public interface IBookingService : IServiceCrud<BookingDto, int>
    {


    }
}
