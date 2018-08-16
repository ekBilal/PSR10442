using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace PSR10442.Web
{
    public partial class Startup
    {
		internal static string ReadTasksScope;

		public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}