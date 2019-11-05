using ReferMe.API.Auth;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferMe.API.Controllers
{
    [RoutePrefix("api/locations")]
    [JwtAuthentication]
    public class LocationController : ApiController
    {
        ILogService loggerService;
        ILocationService _locationService;

        public LocationController(ILogService loggerService, ILocationService locationService)
        {
            this.loggerService = loggerService;
            this._locationService = locationService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<LocationDTO> Locations()
        {
            return _locationService.GetAllLocations();
        }

    }
}
