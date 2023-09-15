using HomeWork1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeWork1.Pages
{
    public class Task5Model : PageModel
    {
        public List<Country> Countries { get; set; }
        public void OnGet()
        {
            Countries = new List<Country>
            {
                new Country
                {
                    Name = "Україна",
                    Capital = "Київ",
                    Population = "44 мільйони",
                    Area = "603,500 кв. км"
                },
                new Country
                {
                    Name = "Сполучені Штати Америки",
                    Capital = "Вашингтон, округ Колумбія",
                    Population = "331 мільйон",
                    Area = "9,525,067 кв. км"
                },
                new Country
                {
                    Name = "Франція",
                    Capital = "Париж",
                    Population = "67 мільйонів",
                    Area = "551,695 кв. км"
                }
            };
        }
    }
}
