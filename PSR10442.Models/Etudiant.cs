using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	public class Etudiant
	{
		public int Id { get; set; }
		[Required, MinLength(8), MaxLength(8), Index(IsUnique =true)]
		public string PSR { get; set; }
		[Required]
		public string Nom { get; set; }
		[Required]
		public string Prenom { get; set; }
		public virtual List<Cours> Inscrit { get; set; }
		public virtual List<Cours> Tuteur { get; set; }
		[Required, DefaultValue(true)]
		public bool estInscrit { get; set; }
	}
}
