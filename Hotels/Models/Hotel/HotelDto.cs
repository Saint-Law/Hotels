using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Hotel
{
    public class HotelDto : BaseHotelDto
    {
        public int Id { get; set; }

    }

    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double? Rating { get; set; }
        public int CountryId { get; set; }
    }
}
