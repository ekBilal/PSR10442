using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using PSR10442.Models;


namespace PSR10442.API.Dal
{
	public class BddContext : DbContext
	{
		internal DbSet<Cours> Cours { get; set; }
		internal DbSet<DemandeSeance> DemandeSeances { get; set; }
		internal DbSet<Etudiant> Etudiant { get; set; }
		internal DbSet<Message> Message { get; set; }
		internal DbSet<Seance> Seances { get; set; }
	}
}