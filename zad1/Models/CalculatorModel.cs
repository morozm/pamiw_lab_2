using System.ComponentModel.DataAnnotations;

namespace zad1.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Podaj pierwszą liczbę")]
        public double Number1 { get; set; }

        [Required(ErrorMessage = "Podaj drugą liczbę")]
        public double Number2 { get; set; }

        public double? Result { get; set; }
    }
}
