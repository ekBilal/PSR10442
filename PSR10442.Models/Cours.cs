﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSR10442.Models
{
	[Table("Cours")]
    public class Cours
    {
		[Key]
		public int IdCours { get; set; }
		[Required]
		public string Nom { get; set; }
		[Required, DefaultValue(true)]
		public bool Actif { get; set; }
	}
}
