using ReferMe.DAL.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Repository;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Implementations
{
    public class LocationService : ILocationService
    {
        IUnitOfWork _unitOfWork;
        ILocationRepository _locationRepository;

        public LocationService(
            IUnitOfWork unitOfWork,
            ILocationRepository roleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._locationRepository = roleRepository;
        }

        public List<LocationDTO> GetAllLocations()
        {
            List<LocationDTO> locations = new List<LocationDTO>();
            this._locationRepository.GetAll().ToList().ForEach(l => locations.Add(new LocationDTO()
            {
                LocationID = l.LocationID,
                City = l.City,
                State = l.State,
                Active = l.Active
            }));

            return locations.Where(location => location.Active).ToList();
        }
    }
}
