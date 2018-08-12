using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	public class Seance
	{
		public int Id { get; set; }
		[Required, ForeignKey("Id")]
		public virtual DemandeSeance Demande { get; set; }
		[Required, ForeignKey("Id")]
		public virtual Etudiant Tuteur { get; set; }
		[Required]
		public DateTime Debut { get; set; }
		[Required]
		public string Lieu { get; set; }

	}
}
