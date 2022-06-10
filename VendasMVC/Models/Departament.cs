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

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();


        public Departament()
        {

        }

        public Departament(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}


