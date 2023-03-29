namespace WebApplication2MVC.Models
{
    public class infoDTO
    {
        public Ogrenci Ogrenci { get; set; }
        public Ogretmen Ogretmen { get; set; }

        public infoDTO()
        {

        }
        public infoDTO(Ogrenci ogrenci, Ogretmen ogretmen)
        {
            this.Ogrenci = ogrenci;
            this.Ogretmen = ogretmen;
        }
    }
}

//DTOlarda aynı objede farklı nesne taşıyabilmek için DTO yani Data Transfer Object kullanıyoruz.
