using PSR10442.CustomDataAnnotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSR10442.Models
{
	public class Seance
	{
		public int Id { get; set; }
		[Required]
		public virtual DemandeSeance Demande { get; set; }
		[Required]
		public virtual Etudiant Tuteur { get; set; }
		[Required, CurrentDate]
		public DateTime Debut { get; set; }
		[Required]
		public string Lieu { get; set; }

	}
}
