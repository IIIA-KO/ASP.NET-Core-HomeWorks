using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeWork1.Models;

namespace HomeWork1.Pages
{
    public class Task2Model : PageModel
    {
        public List<Restaurant> Restaurants { get; set; }

        public void OnGet()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "—макота",
                    Address = "вул. √оловна, ∆итомир",
                    Phone = "+1234567890",
                    Hours = "ѕн-ѕт 11:00-23:00, —б-Ќд 12:00-00:00",
                    Description = "–есторан '—макота' пропонуЇ вам справжню гастроном≥чну подорож св≥том."
                },
                new Restaurant
                {
                    Name = "Ћасунок",
                    Address = "вул. ÷ентральна, ∆итомир",
                    Phone = "+9876543210",
                    Hours = "ѕн-ѕт 10:30-22:30, —б-Ќд 12:30-23:30",
                    Description = "–есторан 'Ћасунок' - це м≥сце, де ви можете смакувати солодощ≥ та десерти з усього св≥ту."
                },
                new Restaurant
                {
                    Name = "—мачно ≥ здорово",
                    Address = "вул. ѕаркова, ∆итомир",
                    Phone = "+5555555555",
                    Hours = "ѕн-ѕт 09:00-21:00, —б-Ќд 10:00-20:00",
                    Description = "–есторан '—мачно ≥ здорово' пропонуЇ смачн≥ та здоров≥ страви дл€ вс≥Їњ родини."
                }
            };
        }
    }
}
