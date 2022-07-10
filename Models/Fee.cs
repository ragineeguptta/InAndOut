using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Fee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be grater than 0")]
        public int Amount { get; set; }

    }
}
