using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	[Table("Cours")]
    public class Cours
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Nom { get; set; }
		[Required]
		public string Intitule{ get; set; }
		[Required, DefaultValue(Etat.Actif)]
		public Etat Etat { get; set; }
}
}
