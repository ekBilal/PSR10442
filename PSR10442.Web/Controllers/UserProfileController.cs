using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using PSR10442.Web.Models;

namespace PSR10442.Web.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
		private static string appKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
		private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private string graphResourceID = "https://graph.windows.net/";
		private static string apiResourceID = "https://ephec.onmicrosoft.com/PSR10442.API";

        // OBTENIR : UserProfile
        public async Task<ActionResult> Index()
        {
            string tenantID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            try
            {
                Uri servicePointUri = new Uri(graphResourceID);
                Uri serviceRoot = new Uri(servicePointUri, tenantID);
                ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                      async () => await GetTokenForApplication());

                // Utiliser le jeton pour interroger l'API Graph et obtenir les détails relatifs à l'utilisateur

                var result = await activeDirectoryClient.Users
                    .Where(u => u.ObjectId.Equals(userObjectID))
                    .ExecuteAsync();
                IUser user = result.CurrentPage.ToList().First();

                return View(user);
            }
            catch (AdalException)
            {
                // Retourner à la page d'erreur.
                return View("Error");
            }
            // En cas d'échec de l'opération ci-dessus, l'utilisateur doit se réauthentifier explicitement pour que l'application obtienne le jeton nécessaire
            catch (Exception)
            {
                return View("Relogin");
            }
        }

        public void RefreshSession()
        {
            HttpContext.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties { RedirectUri = "/UserProfile" },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
        }

        public async Task<string> GetTokenForApplication()
        {
            string signedInUserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            string tenantID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;

            // Obtenir un jeton pour l'API Graph sans intervention de l'utilisateur (à partir du cache, via un jeton d'actualisation multiressource, etc.)
            ClientCredential clientcred = new ClientCredential(clientId, appKey);
            // Initialiser AuthenticationContext avec le cache de jetons de l'utilisateur connecté, tel qu'il figure dans la base de données de l'application
            AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance + tenantID, new ADALTokenCache(signedInUserID));
            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenSilentAsync(graphResourceID, clientcred, new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
            return authenticationResult.AccessToken;
        }

		public static async Task<string> GetTokenForApi()
		{
			string signedInUserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
			string tenantID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
			string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;

			// Obtenir un jeton pour l'API Graph sans intervention de l'utilisateur (à partir du cache, via un jeton d'actualisation multiressource, etc.)
			ClientCredential clientcred = new ClientCredential(clientId, appKey);
			// Initialiser AuthenticationContext avec le cache de jetons de l'utilisateur connecté, tel qu'il figure dans la base de données de l'application
			AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance + tenantID, new ADALTokenCache(signedInUserID));
			AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenSilentAsync(apiResourceID, clientcred, new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
			return authenticationResult.AccessToken;
		}
	}
}
