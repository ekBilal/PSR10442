using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	[Table("Cours")]
    public class Cours
    {
		[Key]
		public int Id;

		public string Nom;
		public string Libele;

    }
}
