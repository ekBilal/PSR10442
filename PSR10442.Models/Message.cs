using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PSR10442.Models
{
	public class Message
	{
		public int Id { get; set; }
		[Required]
		public virtual Etudiant Auteur { get; set; }
		[Required]
		public virtual DemandeSeance Demande { get; set; }
		[Required]
		public string Text { get; set; }
	}
}
