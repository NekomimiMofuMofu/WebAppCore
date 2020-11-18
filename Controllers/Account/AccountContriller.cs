using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text;

#nullable enable

namespace WebAppCore.Controllers.Account {
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase {
		[HttpGet("login")]
		public ActionResult<AccountItem> Get(string request) {
			AccountItem item = new AccountItem();
			try {
				string decode = Encoding.UTF8.GetString(Convert.FromBase64String(request));
				item.Id = decode[..decode.IndexOf('%')];
				item.AccessToken = decode[(decode.IndexOf('%') + 1)..];
				item.StatusCode = AccountItemErrorCheck(item);
				Response.StatusCode = (int)item.StatusCode;
			} catch {
				item.Id = "Error";
				item.AccessToken = "Error";
				item.StatusCode = HttpStatusCode.BadRequest;
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
			}

			return item;
		}

		/// <summary>
		/// アカウント情報アイテムに不整合がないかチェック
		/// </summary>
		/// <param name="item">アカウント情報</param>
		/// <returns>不整合があった場合<see cref="HttpStatusCode.BadRequest"/></returns>
		private static HttpStatusCode AccountItemErrorCheck(AccountItem item) {
			if (item.Id.Equals(string.Empty) || item.AccessToken.Equals(string.Empty)) {
				return HttpStatusCode.BadRequest;
			}
			return HttpStatusCode.OK;
		}
	}
}