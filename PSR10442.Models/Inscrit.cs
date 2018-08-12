using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSR10442.Models
{
	public class Inscrit
	{
		[Key]
		public int IdIscrit { get; set; }
		public virtual Cours Cours { get; set; }
		public virtual Etudiant Etudiant { get; set; }
		[DefaultValue(false)]
		public bool Tuteur { get; set; }
	}
}
