using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeToFoodByFabien.Models
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        [Key]
        public int FoodId { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public string CuisineName { get; set; }
        public int Price { get; set; }
    }
}