using AutoMapper;
using VehicleHub.Rental.Api.ViewModel;
using VehicleHub.Rental.DAL.Models;

namespace VehicleHub.Rental.Api
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<VehicleViewModel, Vehicle>();
        }
    }
}
