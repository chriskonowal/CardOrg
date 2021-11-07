using CardOrg.Converters;
using CardOrg.Interfaces.Repositories;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Services
{
    /// <summary>
    /// The location service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.ILocationService" />
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class.
        /// </summary>
        /// <param name="locationRepository">The location repository.</param>
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LocationViewModel>> GetLocationsAsync(CancellationToken cancellationToken)
        {
            var entities = await _locationRepository.GetLocationsAsync(cancellationToken).ConfigureAwait(false);
            return entities.Select(x => LocationViewModelConverter.Convert(x));
        }

        /// <inheritdoc/>
        public async Task<int> SaveLocationAsync(LocationViewModel model, CancellationToken cancellationToken)
        {
            if (model.LocationId  > 0)
            {
                var entity = LocationViewModelConverter.Convert(model);
                return await _locationRepository.UpdateLocationAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return await _locationRepository.InsertLocationAsync(model.Name, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<LocationViewModel> GetLocationAsync(int locationId, CancellationToken cancellationToken)
        {
            var entity = await _locationRepository.GetLocationAsync(locationId, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return null;
            }
            return LocationViewModelConverter.Convert(entity);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteLocationAsync(int locationId, CancellationToken cancellationToken)
        {
            return await _locationRepository.DeleteLocationAsync(locationId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LocationViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var entities = await _locationRepository.GetByIdsAsync(ids, cancellationToken).ConfigureAwait(false);
            return entities.Select(x => LocationViewModelConverter.Convert(x));
        }
    }
}
