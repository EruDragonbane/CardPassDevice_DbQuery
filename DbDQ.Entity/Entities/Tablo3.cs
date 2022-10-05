using System.ComponentModel.DataAnnotations;

namespace DbDQ.Entity.Entities
{
    public class Tablo3
    {
        [Key]
        public int Id { get; set; }

        public int? Tablo2Id { get; set; }

        public Tablo2 Tablo2 { get; set; }
    }
}