using System.ComponentModel.DataAnnotations;

namespace Store.Api.ControllerParams
{
    public class CategoryParams
    {
        [Required]
        public string Name { get; set; }
    }
}