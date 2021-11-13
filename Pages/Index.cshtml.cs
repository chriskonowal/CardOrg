using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Pages
{
    /// <summary>
    /// The index model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class IndexModel : PageModel
    {
        private readonly ICardService _cardService;

        public IndexModel(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Gets or sets the card view models.
        /// </summary>
        /// <value>
        /// The card view models.
        /// </value>
        [BindProperty]
        public IEnumerable<CardViewModel> CardViewModels { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(CancellationToken cancellationToken)
        {
            CardViewModels = await _cardService.GetTop10NewestCardsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
