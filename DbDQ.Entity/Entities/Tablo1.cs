using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbDQ.Entity.Entities
{
    public class Tablo1
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public string AdSoyad { get; set; }
    
        public ICollection<Tablo2> Tablo2 { get; set; }
    }
}
