using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Forms
{
    public class CustomPizzaModel : PageModel
    {
        [BindProperty]
        public PizzasModel Pizza { get; set; }
        public decimal PizzaPrice { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            PizzaPrice = Pizza.BasePrice;
            if (Pizza.TomatoSauce) PizzaPrice += 1;
            if (Pizza.Cheese) PizzaPrice += 1;
            if (Pizza.Tuna) PizzaPrice += 1; 
            if (Pizza.Ham) PizzaPrice += 1;
            if (Pizza.Mushroom) PizzaPrice += 1;
            if (Pizza.Peperoni) PizzaPrice += 1;
            if (Pizza.Pineapple) PizzaPrice += 10;
            if (Pizza.Beef) PizzaPrice += 1;
            
            Pizza.FinalPrice = PizzaPrice;

            //create new object with two feilds 
            return RedirectToPage("/Checkout/Checkout", new {Pizza.PizzaName, PizzaPrice});
            //return RedirectToPage("/Checkout/Checkout", new { Pizza});
        }

    }
}
