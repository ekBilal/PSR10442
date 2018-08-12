using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PSR10442.Models;


namespace PSR10442.API.Models
{
	public interface IDal:IDisposable
	{
		//COURS
		
		/// <summary>
		/// Ajouter un cours
		/// </summary>
		/// <param name="cours">Le cours a ajouter dans la base de donnée</param>
		/// <returns>Le cours ajouté avec son Id en DB</returns>
		Cours AddCours(Cours cours);

		/// <summary>
		/// Ajouter un cours seulement avec son nom
		/// L'intitulé sera fourni automatiquement
		/// </summary>
		/// <param name="nom">Le nom du cours</param>
		/// <returns>Le cours ajouté avec son intitulé et son Id en DB</returns>
		Cours AddCours(string nom);

		/// <summary>
		/// Ajouter un cours en présisant son nom et son intitlé
		/// </summary>
		/// <param name="nom">Le nom du cours</param>
		/// <param name="intitule">L'intitulé du cours</param>
		/// <returns>Le cours ajouté avec son Id en DB</returns>
		Cours AddCours(string nom, string intitule);

		Cours GetCours(int Id);
		List<Cours> GetAllCours();

		Cours SetCours(Cours cours);
		Cours SetCours(int Id, Cours cours);

		bool DeleteCours(Cours cours);
		bool DeleteCours(int Id);






		//Demande Seance CRUD
		//Create
		DemandeSeance AddDemande(DemandeSeance demandeSeance);
		DemandeSeance AddDemande(Etudiant etudiant, Cours cours);

		//Read
		DemandeSeance GetDemande(int Id);
		DemandeSeance GetLastDemande();

		List<DemandeSeance> GetDemandes();

		List<DemandeSeance> GetDemandesEtudiant(int id);
		List<DemandeSeance> GetDemandesEtudiant(Etudiant etudiant);

		List<DemandeSeance> GetDemandesCours(int id);
		List<DemandeSeance> GetDemandesCours(Cours cours);

		//Pas d'UPDATE

		//Delete
		void DeleteDemande(int id);
		void DeleteDemande(DemandeSeance demande);

		//ETUDIANT
		//Create
		Etudiant AddEtudiant(Etudiant etudiant);
		Etudiant AddEtudiant(string psr, string nom, string prenom);

		//Read
		Etudiant GetEtudiant(int id);
		List<Etudiant> GetEtudiants();

		//Update
		bool InscrireAUnCours(Etudiant etudiant, Cours cours);
		bool InscrireAUnCours(int idEtudiant, int idCours);
		bool AddTuteur(Etudiant etudiant, Cours cours);
		bool AddTuteur(int idEtudiant, int idCours);

		//Delete
		bool Desinscrire(Etudiant etudiant);
		bool Desinscrire(int id);

		//Message
		//Create
		Message AddMessage(Etudiant auteur, DemandeSeance demande, string text);
		//Reade
		List<Message> GetMessages(DemandeSeance demande);
		//Update
		Message SetMessage(Etudiant etudiant, DemandeSeance demande, string text);
		//Delete
		bool DeleteMessage(Message message);
		bool DeleteMessage(int id);


		//SEANCE
		//Create
		Seance AddSeance(Seance seance);
		//Read
		Seance GetSeance(int id);
		List<Seance> GetSeances(Cours cours);
		List<Seance> GetSeances(Etudiant etudiant);

		//Update
		Seance SetSeance(Seance seance);

		//Delete
		Seance DeleteSeance(Seance seance);























	}
}