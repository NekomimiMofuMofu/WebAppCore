using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebAppCore.Controllers.Account {
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase {
		[HttpGet("login")]
		public ActionResult<AccountItem> Get(string request) {
			AccountItem item = new AccountItem();
			try {
				string decode = Encoding.UTF8.GetString(Convert.FromBase64String(request));
				string id = decode[..decode.IndexOf('%')];
				if (id.Equals(string.Empty)) {
					item.Id = "N/a";
					item.AccessToken = "N/a";
					item.StatusCode = HttpStatusCode.BadRequest;
					Response.StatusCode = (int)HttpStatusCode.BadRequest;
					return item;
				}
				item.Id = id;
				
				string password = decode[(decode.IndexOf('%') + 1)..];
				if (password.Equals(string.Empty)) {
					item.AccessToken = "N/a";
					item.StatusCode = HttpStatusCode.BadRequest;
					Response.StatusCode = (int) HttpStatusCode.BadRequest;
					return item;
				}

				item.AccessToken = password;
				item.StatusCode = HttpStatusCode.OK;

			} catch {
				item.Id = "N/a";
				item.AccessToken = "N/a";
				item.StatusCode = HttpStatusCode.BadRequest;
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
			}

			return item;
		}
	}
}