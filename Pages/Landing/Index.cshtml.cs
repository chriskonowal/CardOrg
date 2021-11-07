using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Landing
{
    /// <summary>
    /// The index model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class IndexModel : PageModel
    {
        private readonly ICardRepository _cardRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="cardRepository">The card repository.</param>
        public IndexModel(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        /// <summary>
        /// Gets or sets the card entities.
        /// </summary>
        /// <value>
        /// The card entities.
        /// </value>
        [BindProperty]
        public IEnumerable<Entities.CardEntity> CardEntities { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(CancellationToken cancellationToken)
        {
            CardEntities = await _cardRepository.GetCardsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
