using System.ComponentModel.DataAnnotations;
using OdeToFoodByFabien.Models;


namespace OdeToFoodByFabien.ViewModels
{
    /**/
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}