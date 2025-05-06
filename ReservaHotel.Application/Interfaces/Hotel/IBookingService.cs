using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Application.Interfaces.Hotel
{
    public interface IBookingService : IServiceCrud<BookingDto, int>
    {


    }
}
