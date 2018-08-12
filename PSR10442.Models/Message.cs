using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	public class Message
	{
		[Key]
		public int Id { get; set; }
		[Required, ForeignKey("Id")]
		public virtual Etudiant Etudiant { get; set; }
		[Required, ForeignKey("Id")]
		public virtual DemandeSeance Demande { get; set; }
		[Required]
		public string Text { get; set; }
	}
}
