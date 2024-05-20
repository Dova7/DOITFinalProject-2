using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(10000)]
        public string Body { get; set; } = null!;
    }
}
