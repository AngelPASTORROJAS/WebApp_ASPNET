using System.ComponentModel.DataAnnotations.Schema;
using WebApp_ASPNET.ModelsDTO;

namespace WebApp_ASPNET.Models
{
    public class Contact
    {
        [Key]
        [Required(ErrorMessage = "Nom complet est requis.")]
        [StringLength(maximumLength: 71, MinimumLength = 2)]
        public string Fullname { get; set; }

        public DateTime? Naissance { get; set; }

        [StringLength(2083)]
        public string? Avatar { get; set; }

        [Range(0, 999, ErrorMessage = "L'âge doit être compris entre 0 et 999")]
        public int? Age { get; set; }

        [StringLength(35)]
        public string? Nom { get; set; }

        [StringLength(35)]
        public string? Prenom { get; set; }

        [Required]
        [ForeignKey("Sexe")]
        [StringLength(1)]
        public string Genre { get; set; }
        public Sexe Sexe { get; set; }

        public static implicit operator Contact(ContactDTO contactDto)
        {
            return new Contact
            {
                Fullname = contactDto.Fullname,
                Naissance = contactDto.Naissance,
                Avatar = contactDto.Avatar,
                Age = contactDto.Age,
                Nom = contactDto.Nom,
                Prenom = contactDto.Prenom,
                Genre = contactDto.Genre
            };
        }
    }
}
