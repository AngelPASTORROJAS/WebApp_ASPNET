namespace WebApp_ASPNET.ModelsDTO
{
    public class SexeDTO
    {
        [Key]
        [Required(ErrorMessage = "Genre est requis")]
        [StringLength(1)]
        public string Genre { get; set; }

        public static implicit operator SexeDTO(Sexe sexe)
        {
            return new SexeDTO { 
                Genre = sexe.Genre
            };
        }
    }
}
