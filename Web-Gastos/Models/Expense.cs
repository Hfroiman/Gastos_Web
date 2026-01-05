using System.ComponentModel.DataAnnotations;

namespace Web_Gastos.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
