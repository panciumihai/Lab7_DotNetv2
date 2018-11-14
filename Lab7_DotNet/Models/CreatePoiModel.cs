

using System.ComponentModel.DataAnnotations;

namespace Lab7_DotNet
{
    public class CreatePoiModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(50)]
        public string Description { get; set; }
    }
}
