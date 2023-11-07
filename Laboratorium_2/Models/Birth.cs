using Laboratorium_2.Controllers;

namespace Laboratorium_2.Models
{
    public class Birth
    {
        public string Imie { get; set; }
        public DateTime Data { get; set; }
        DateTime currentTime = DateTime.Now;

        public bool IsValid()
        {
            return !(String.IsNullOrEmpty(Imie)) && Data < DateTime.Now && Data != default(DateTime);
        }

        public int Birth_Calculate()
        {
            return currentTime.Year - Data.Year;
        }
    }
}
