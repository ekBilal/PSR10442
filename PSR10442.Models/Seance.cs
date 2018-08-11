using System.ComponentModel.DataAnnotations;

namespace PSR10442.Models
{
	public class Seance
	{
		public int Id { get; set; }
		[Required]
		public virtual Cours Cours { get; set; }
		[Required]
		public virtual DemandeSeance Demande { get; set; }
		[Required]
		public virtual Etudiant Tuteur { get; set; }
		[Required]
		public string Lieu { get; set; }

	}
}
