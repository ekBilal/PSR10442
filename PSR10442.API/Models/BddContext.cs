using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using PSR10442.Models;


namespace PSR10442.API.Models
{
	public class BddContext : DbContext
	{
		public DbSet<Cours> Cours { get; set; }
		public DbSet<Etudiant> Etudiant { get; set; }
		public DbSet<Inscrit> Inscrit { get; set; }
	}
}