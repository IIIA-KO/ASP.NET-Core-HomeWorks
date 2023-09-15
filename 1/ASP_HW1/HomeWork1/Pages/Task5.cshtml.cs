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
                    Name = "������",
                    Capital = "���",
                    Population = "44 �������",
                    Area = "603,500 ��. ��"
                },
                new Country
                {
                    Name = "�������� ����� �������",
                    Capital = "���������, ����� �������",
                    Population = "331 ������",
                    Area = "9,525,067 ��. ��"
                },
                new Country
                {
                    Name = "�������",
                    Capital = "�����",
                    Population = "67 �������",
                    Area = "551,695 ��. ��"
                }
            };
        }
    }
}
