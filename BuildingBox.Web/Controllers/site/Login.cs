using DataModel;
using LinqToDB;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Threading;
using System.Linq;
using System.Security.Claims;

namespace BuildingBox.Web
{
	public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
	{
		public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
			await System.Threading.Tasks.Task.FromResult(0);
		}

		public override async System.Threading.Tasks.Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			using (var db = new BuildingBoxDB())
			{
				var usuario = new User().Login(db, context.UserName, context.Password);

				if (usuario != null)
				{
					var identity = new ClaimsIdentity(context.Options.AuthenticationType);

					identity.AddClaim(new Claim(ClaimTypes.Name, usuario.stContactEmail));
					identity.AddClaim(new Claim(ClaimTypes.Sid, usuario.id.ToString()));
										
					var ticket = new AuthenticationTicket(identity, null);
					context.Validated(ticket);
				}
				else
				{
					context.SetError("invalid_grant", "Invalid login / password!");
					return;
				}

				await System.Threading.Tasks.Task.FromResult(0);
			}
		}

		public override System.Threading.Tasks.Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			string nameUser = context.Identity.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault();
			
			context.AdditionalResponseParameters.Add("nameUser", nameUser);
			
			return System.Threading.Tasks.Task.FromResult<object>(null);
		}
	}
}