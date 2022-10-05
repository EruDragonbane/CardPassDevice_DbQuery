using System;
using System.ComponentModel.DataAnnotations;

namespace DbDQ.Entity.Entities
{
    public class Tablo4
    {
        [Key]
        public int Id { get; set; }

        public int? Tablo3Id { get; set; }
        public DateTime? GecisDateTime { get; set; }

        public Tablo3 Tablo3 { get; set; }
    }
}