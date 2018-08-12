using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSR10442.CustomDataAnnotations;

namespace PSR10442.Models
{
	public class DemandeSeance
	{
		public int Id { get; set; }
		[Required]
		public virtual Etudiant Etudiant { get; set; }
		[Required, CurrentDate]
		public DateTime Debut { get; set; }
		[Required, CurrentDate]
		public DateTime Fin { get; set; }
		public string Commentaire { get; set; }
		[Required, DefaultValue(EtatDemande.EnAttente)]
		public Etat Etat { get; set; }
	}
}
