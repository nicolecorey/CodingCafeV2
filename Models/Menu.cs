using System.ComponentModel.DataAnnotations;
using PagedList;


namespace CodingCafeV2.Models
{
    public class Menu
    {
        [Display(Name = "Menu ID")]
        public int MenuId { get; set; }

        [Display(Name = "Menu Item")]
        public string Item {  get; set; }
        public string Description { get; set; }
    }
}
