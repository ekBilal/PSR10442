using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PSR10442.Models;


namespace PSR10442.API.Dal
{
	public interface IDal:IDisposable
	{
		//Cours
		Cours AddCours(Cours cours);
		Cours AddCours(string nom);
		Cours AddCours(string nom, string intitule);

		Cours GetCours(int Id);
		List<Cours> GetAllCours();

		Cours SetCours(Cours cours);
		Cours SetCours(int Id, Cours cours);

		bool DeleteCours(Cours cours);
		bool DeleteCours(int Id);
	}
}