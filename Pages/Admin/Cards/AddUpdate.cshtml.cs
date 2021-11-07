using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Repositories;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.Cards
{
    /// <summary>
    /// The add update model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class AddUpdateModel : PageModel
    {
        private readonly ICardService _cardService;
        private readonly ISportService _sportService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUpdateModel"/> class.
        /// </summary>
        /// <param name="saveCardService">The save card service.</param>
        public AddUpdateModel(ICardService cardService,
            ISportService sportService)
        {
            _cardService = cardService;
            _sportService = sportService;
        }

        /// <summary>
        /// Gets or sets the card view model.
        /// </summary>
        /// <value>
        /// The card view model.
        /// </value>
        [BindProperty]
        public CardViewModel CardViewModel { get; set; }

        [BindProperty]
        public IEnumerable<SportViewModel> SportViewModels { get; set; }

        /// <summary>
        /// Called when [get].
        /// </summary>
        public async Task<IActionResult> OnGetAsync(CancellationToken cancellationToken)
        {
            ViewData["Success"] = "Add/Update Card";
            CardViewModel = new CardViewModel();
            SportViewModels = await _sportService.GetSportsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }

        /// <summary>
        /// Called when [post asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var result = await _cardService.SaveCardAsync(CardViewModel, cancellationToken).ConfigureAwait(false);
            //ModelState.Clear();
            //CardViewModel = null;
            //if (result)
            //{
            //    ViewData["Success"] = "Success! Add another card.";
            //    return Page();
            //}
            //else
            //{
            //    ViewData["Success"] = "Error!";
            //    return Page();
            //}
            return Page();
        }
    }
}
