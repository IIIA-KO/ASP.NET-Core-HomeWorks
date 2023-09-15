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
                    Name = "�������",
                    Address = "���. �������, �������",
                    Phone = "+1234567890",
                    Hours = "��-�� 11:00-23:00, ��-�� 12:00-00:00",
                    Description = "�������� '�������' ������� ��� �������� ������������ ������� �����."
                },
                new Restaurant
                {
                    Name = "�������",
                    Address = "���. ����������, �������",
                    Phone = "+9876543210",
                    Hours = "��-�� 10:30-22:30, ��-�� 12:30-23:30",
                    Description = "�������� '�������' - �� ����, �� �� ������ ��������� �������� �� ������� � ������ ����."
                },
                new Restaurant
                {
                    Name = "������ � �������",
                    Address = "���. �������, �������",
                    Phone = "+5555555555",
                    Hours = "��-�� 09:00-21:00, ��-�� 10:00-20:00",
                    Description = "�������� '������ � �������' ������� ����� �� ������ ������ ��� �񳺿 ������."
                }
            };
        }
    }
}
