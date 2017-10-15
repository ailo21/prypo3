using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prypo3.DataModel
{
    public class Fant
    {
        [Key]
        public int Id { get; set; }= new int();      
        [MaxLength(256)]
        [Required]
        [DisplayName("Название вызова")]
        public string Title { get; set; }
        public string Photo { get; set; }
        [MaxLength(128)]
        public string Author { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [DisplayName("Описание вызова")]
        public string Text { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Доказательство")]
        public string Proof { get; set;}
        public bool Publish { get; set; } = false;
        //public IEnumerable<Tag> Tags { get; set; }
    }
}