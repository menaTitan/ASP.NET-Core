using Microsoft.EntityFrameworkCore;
using MVCLibaray.Models;
using MVCLibrary.Data;

namespace MVCLibrary.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>())) 
            {
                if (context.Book.Any())
                {
                    return;
                }
                context.Book.AddRange(new Book { Title = "In Saint Joseph's Footsteps", Author="FR. Mark Toups",CallNumber = "AXD 2029" },
                    new Book { Title = "Psychology Of Money", Author="Morgan Housel" ,CallNumber = "AXD 2030" },
                    new Book { Title = "Thinking Fast and Slow",Author="Daniel Kahneman" ,CallNumber = "AXD 2031" },
                    new Book { Title = "Art of Choosing", Author="Sheena Lyebgar" ,CallNumber = "AXD 2032" },
                    new Book { Title = "Love and Responsibility", Author = "Karol Wojtyla (POPE John Paul II)", CallNumber = "AXD 2033" });

                context.SaveChanges();
            }
        }
    }
}
