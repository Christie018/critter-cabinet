using System.ComponentModel.DataAnnotations;

namespace CritterCabinet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is needed")]
        public string Type { get; set; }

        [StringLength(50, ErrorMessage = "Breed cannot be longer than 50 characters.")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status {get; set; }
    }
}
