using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    public interface ISearchSortRepository
    {
        Task<IEnumerable<SearchSortEntity>> GetSearchSortAsync(CancellationToken cancellationToken);

        Task<SearchSortEntity> InsertSearchSortAsync(SearchSortEntity entity, CancellationToken cancellationToken);
    }
}
