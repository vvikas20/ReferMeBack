using ReferMe.Common.Helper;
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
            var predicate = PredicateBuilder.True<Model.Entity.Location>();
            predicate = predicate.And(i => i.Active);
            List<Model.Entity.Location> queryResult = _locationRepository.GetMany(predicate).ToList();

            List<LocationDTO> locations = new List<LocationDTO>();
            queryResult.ForEach(l => locations.Add(new LocationDTO()
            {
                LocationID = l.LocationID,
                City = l.City,
                State = l.State,
                Active = l.Active
            }));

            return locations;
        }
    }
}
