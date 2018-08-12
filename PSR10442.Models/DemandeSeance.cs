using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	public class DemandeSeance
	{
		public int Id { get; set; }
		[Required, ForeignKey("Id")]
		public virtual Etudiant Etudiant { get; set; }
		[Required, ForeignKey("Id")]
		public virtual Cours cours { get; set; }
		public string Commentaire { get; set; }
		[Required, DefaultValue(Etat.EnAttente)]
		public Etat Etat { get; set; }
	}
}
