using WebApp_ASPNET.ModelsDTO;

namespace WebApp_ASPNET.Models
{
    public class Sexe
    {
        [Key]
        [Required(ErrorMessage = "Genre est requis")]
        [StringLength(1)]
        public string Genre { get; set; }

        public static implicit operator Sexe(SexeDTO sexeDto)
        {
            return new Sexe
            {
                Genre = sexeDto.Genre
            };
        }
    }
}
