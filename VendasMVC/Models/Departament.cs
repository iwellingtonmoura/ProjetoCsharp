using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasMVC.Models
{
    [Table("Departament")]

	public class Departament
	{

        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Name")]
        public string? Name { get; set; }
    }
}


