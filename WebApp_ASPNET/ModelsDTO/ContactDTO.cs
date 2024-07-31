using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_ASPNET.ModelsDTO
{
    public class ContactDTO
    {
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
        [StringLength(1)]
        public string Genre { get; set; }

        public static implicit operator ContactDTO(Contact contact)
        {
            return new ContactDTO
            {
                Fullname = contact.Fullname,
                Naissance = contact.Naissance,
                Avatar = contact.Avatar,
                Age = contact.Age,
                Nom = contact.Nom,
                Prenom = contact.Prenom,
                Genre = contact.Genre
            };
        }
    }
}
