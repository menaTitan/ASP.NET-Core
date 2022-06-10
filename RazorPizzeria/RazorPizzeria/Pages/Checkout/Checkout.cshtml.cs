using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet =true)]
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CheckoutModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
        public string ImageTitle { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(PizzaName)) PizzaName = "Custom";
            if (string.IsNullOrWhiteSpace(ImageTitle)) ImageTitle = "Create";
            _applicationDbContext.PizzaOrders.Add(new PizzaOrder { PizzaName = PizzaName, BasePrice = PizzaPrice });
            _applicationDbContext.SaveChanges();
        }
    }
}
