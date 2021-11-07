using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The team card repository
    /// </summary>
    public interface ITeamCardRepository
    {
        Task<IEnumerable<TeamCardEntity>> GetTeamCardsAsync(IEnumerable<int> cardIds, CancellationToken cancellationToken);
    }
}
