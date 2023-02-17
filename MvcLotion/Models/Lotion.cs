using System.ComponentModel.DataAnnotations;
using System;

namespace MvcLotion.Models
{
    public class Lotion
    {
        public int Id { get; set; }
        public string Ingredients { get; set; }
        public string SkinType { get; set; }
        public string Texture { get; set; }
        public string Purpose { get; set; }
        public string Scent { get; set; }
        public decimal Price { get; set; }
    }
}
