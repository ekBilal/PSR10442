using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	public class Etudiant
	{
		[Key]
		public int IdEtudiant { get; set; }
		[Required, MinLength(5), MaxLength(5), Index(IsUnique =true)]
		public string PSR { get; set; }
		[Required]
		public string Nom { get; set; }
		[Required]
		public string Prenom { get; set; }
		[Required, DefaultValue(true)]
		public bool estInscrit { get; set; }
	}
}
