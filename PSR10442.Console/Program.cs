using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSR10442.Bash
{
	class Program
	{
		static void Main(string[] args)
		{

			Dal dal = new Dal();

			var etudiant = dal.AddEtudiant("El Khattouti", "Bilal", "10442");
			var cours = dal.AddCours("Anglais");
			var inscription = dal.Inscrire(etudiant, cours);
			Console.ReadKey();

		}
	}
}
