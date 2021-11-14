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
    public class SearchSortService : ISearchSortService
    {
        private readonly ISearchSortRepository _searchSortRepository;

        public SearchSortService(ISearchSortRepository searchSortRepository)
        {
            _searchSortRepository = searchSortRepository;
        }

        public async Task<IEnumerable<SearchSortViewModel>> GetSearchSortAsync(CancellationToken cancellationToken)
        {
            var result = await _searchSortRepository.GetSearchSortAsync(cancellationToken).ConfigureAwait(false);
            return result.Select(x => SearchSortViewModelConverter.Convert(x));
        }

        public async Task<SearchSortViewModel> GetSearchSortByIdAsync(int searchSortId, CancellationToken cancellationToken)
        {
            var result = await _searchSortRepository.GetSearchSortByIdAsync(searchSortId, cancellationToken).ConfigureAwait(false);
            return SearchSortViewModelConverter.Convert(result);
        }

        public async Task<SearchSortViewModel> SaveSearchSortAsync(SearchSortViewModel entity, CancellationToken cancellationToken)
        {
            var model = SearchSortViewModelConverter.Convert(entity);
            var result = await _searchSortRepository.InsertSearchSortAsync(model, cancellationToken).ConfigureAwait(false);
            return SearchSortViewModelConverter.Convert(result);
        }

        public async Task<int> DeleteSearchSortAsync(int searchSortId, CancellationToken cancellationToken)
        {
            return await _searchSortRepository.DeleteSearchSortAsync(searchSortId, cancellationToken).ConfigureAwait(false);
        }
    }
}
