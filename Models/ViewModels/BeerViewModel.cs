using System.ComponentModel.DataAnnotations;

namespace ASPModelViewController.Models.ViewModels
{
    public class BeerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public long BrandId { get; set; }
    }
}
