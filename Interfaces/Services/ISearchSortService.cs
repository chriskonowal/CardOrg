using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    public interface ISearchSortService
    {
        Task<IEnumerable<SearchSortViewModel>> GetSearchSortAsync(CancellationToken cancellationToken);

        Task<SearchSortViewModel> SaveSearchSortAsync(SearchSortViewModel entity, CancellationToken cancellationToken);

        Task<int> DeleteSearchSortAsync(int searchSortId, CancellationToken cancellationToken);

        Task<SearchSortViewModel> GetSearchSortByIdAsync(int searchSortId, CancellationToken cancellationToken);
    }
}
