using System;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        private readonly ICheckOutPageService _checkOutPageService;

        public CheckOutModel(ICheckOutPageService checkOutPageService)
        {
            _checkOutPageService = checkOutPageService ?? throw new ArgumentNullException(nameof(checkOutPageService));
        }

        public CartViewModel CartViewModel { get; set; } = new CartViewModel();

        [BindProperty]
        public OrderViewModel Order { get; set; }

        public async Task OnGetAsync()
        {
            CartViewModel = await _checkOutPageService.GetCart(User.Identity.Name);
        }        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CartViewModel = await _checkOutPageService.GetCart(User.Identity.Name);
                return Page();
            }
            
            await _checkOutPageService.CheckOut(Order, User.Identity.Name);
            return RedirectToPage("./OrderSubmitted");
        }        
    }
}