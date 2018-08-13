using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


using PSR10442.Models;

namespace PSR10442.API.Models
{
	public class Dal : IDisposable
	{
		private BddContext bdd;

		public Dal()
		{
			bdd = new BddContext();
		}

		//COURS
		public Cours AddCours(string nom)
		{
			var cours = new Cours { Nom = nom, Actif = true };
			try
			{
				bdd.Cours.Add(cours);
				bdd.SaveChanges();
			}
			catch (Exception)
			{
			}
			return cours;
		}



		public ICollection<Cours> GetCours()
		{
			return bdd.Cours.Where(c => c.Actif == true).ToList();
		}

		public Cours GetCours(int id)
		{
			var cours = bdd.Cours.Find(id);
			if (cours == null) throw new ObjectNotFoundException();
			return cours;
		}

		public Cours SetCours(Cours cours)
		{
			var oldCours = GetCours(cours.IdCours);
			oldCours.Nom = cours.Nom;
			oldCours.Actif = cours.Actif;
			bdd.SaveChanges();
			return oldCours;
		}

		public void DeleteCours(Cours cours)
		{
			DeleteCours(cours.IdCours);
		}

		public void DeleteCours(int id)
		{
			var cours = GetCours(id);
			cours.Actif = false;
			bdd.SaveChanges();
		}




		//DEMANDE
		/**
		public DemandeSeance AddDemande(DemandeSeance demande)
		{
			bdd.DemandeSeances.Add(demande);
			bdd.SaveChanges();
			return demande;
		}

		public DemandeSeance GetDemandeSeance(int id)
		{
			var demande = bdd.DemandeSeances.FirstOrDefault(d => d.Id == id);
			if (demande == null) throw new Exception("demande introuvable");
			return demande;
		}


		public DemandeSeance SetEtatDemande(int idDemande, Etat etat)
		{
			var demande = GetDemandeSeance(idDemande);
			demande.Etat = etat;
			bdd.SaveChanges();
			return demande;
		}

		public DemandeSeance DeleteDemande(int id)
		{
			return SetEtatDemande(id, Etat.Annule);
		}

			**/
		//ETUDIANT
		public Etudiant AddEtudiant(Etudiant etudiant)
		{
			bdd.Etudiant.Add(etudiant);
			bdd.SaveChanges();
			return etudiant;
		}

		public IQueryable<Etudiant> GetEtudiants()
		{
			var etudiants = bdd.Etudiant.Where(e => e.estInscrit == true);
			return etudiants;
		}

		public Etudiant GetEtudiant(int id)
		{
			var etudiant = bdd.Etudiant.Find(id);
			return etudiant;
		}

		public Etudiant SetEtudiant(int id, bool estInscrit)
		{
			var etudiant = bdd.Etudiant.Find(id);
			if (etudiant == null) throw new ObjectNotFoundException();
			etudiant.estInscrit = estInscrit;
			bdd.SaveChanges();
			return etudiant;
		}

		public bool DeleteEtudiant(int id)
		{
			var etudiant = bdd.Etudiant.Find(id);
			if (etudiant == null) throw new ObjectNotFoundException();
			etudiant.estInscrit = false;
			try
			{
				bdd.SaveChanges();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		//public Etudiant InscrireCours(int idEtudiant, Cours cours)
		//{
		//	var etudiant = GetEtudiant(idEtudiant);
		//	etudiant.Inscrit.Add(cours);
		//	bdd.SaveChanges();
		//	return etudiant;
		//}

		//public Etudiant Tuteur(int idEtudiant, Cours cours)
		//{
		//	var etudiant = GetEtudiant(idEtudiant);
		//	etudiant.Tuteur.Add(cours);
		//	bdd.SaveChanges();
		//	return etudiant;
		//}

		public void Desinscire(int idEtudiant)
		{
			var etudiant = GetEtudiant(idEtudiant);
			etudiant.estInscrit = false;
			bdd.SaveChanges();
		}


		//INSCRIT

		public Inscrit Inscrire(Etudiant etudiant, Cours cours)
		{
			var inscription = new Inscrit { Etudiant = etudiant, Cours = cours };
			bdd.Inscrit.Add(inscription);
			bdd.SaveChanges();
			return inscription;
		}

		public Inscrit Inscrire(int idEtudiant, int idCours)
		{
			var etudiant = GetEtudiant(idEtudiant);
			var cours = GetCours(idCours);
			return Inscrire(etudiant, cours);
		}

		public IList<Inscrit> GetEtudiantInscrit(int idCours)
		{
			var inscrits = bdd.Inscrit.Where(i => i.Cours.IdCours == idCours).ToList();

			return inscrits;
		}

		/**
		//MESSAGE
		public Message Message(Etudiant auteur, DemandeSeance demande, string text)
		{
			Message message = new Message { Etudiant = auteur, Demande = demande, Text = text };
			bdd.Message.Add(message);
			bdd.SaveChanges();
			return message;
		}

		public ICollection<Message> GetMessages(int idDemande)
		{
			var messages = bdd.Message.Where(m => m.Demande.Id == idDemande).ToList();
			return messages;
		}

		//pas d'update
		//pas de delete

		//SEANCE
		public Seance AddSeance(Seance seance)
		{
			var demande = GetDemandeSeance(seance.Demande.Id);
			demande.Etat = Etat.Accepte;
			bdd.Seances.Add(seance);
			bdd.SaveChanges();
			return seance;
		}

		public Seance GetSeance(int id)
		{
			var seance = bdd.Seances.FirstOrDefault(s => s.Id == id);
			if (seance == null) throw new Exception("seance introuvabe");
			return seance;
		}

		public Seance SetSeance(Seance seance)
		{
			var oldSeance = GetSeance(seance.Id);
			oldSeance = seance;
			bdd.SaveChanges();
			return seance;
		}

		public void AnnulerSeance(Seance seance)
		{
			var demande = GetDemandeSeance(seance.Demande.Id);
			demande.Etat = Etat.Annule;
			bdd.SaveChanges();
		}


	**/



		public void Dispose()
		{
			bdd.Dispose();
		}
	}
}