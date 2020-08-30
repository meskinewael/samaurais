using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ConsoleApp1
{
   public class Samaurais
    {
        public Samaurais()
        {
            Quotes = new List<Quote>();
        }
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(10) ]
        public string Name { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public List<Quote> Quotes { get; set; }
        public Clan Clan { get; set; }
    }
}
