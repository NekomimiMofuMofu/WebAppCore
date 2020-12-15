using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebAppCore.Util;

#nullable enable

namespace WebAppCore.Controllers.Account {
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase {

		/// <summary>
		/// ログインAPI
		/// </summary>
		/// <param name="request">リクエストデータ</param>
		/// <returns>Response</returns>
		[HttpGet("login")]
		public ActionResult<AccountItem> Login(string request) {
			AccountItem item = new AccountItem();
			try {
				string decode = Encoding.UTF8.GetString(Convert.FromBase64String(request));
				item.Id = decode[..decode.IndexOf('%')];
				item.AccessToken = decode[(decode.IndexOf('%') + 1)..];
				item.StatusCode = AccountItemErrorCheck(item);
				Response.StatusCode = (int)item.StatusCode;
				if (item.StatusCode == HttpStatusCode.OK) {
					item.AccessToken = decode + DateTime.Now.ToString("&yyyy-MM-dd:hh-mm-ss");
					item.AccessToken = Sha256Util.GetSha256HashedString(item.AccessToken);
				}
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
				item.AccessToken = "EmptyError";
				return HttpStatusCode.BadRequest;
			}

			if (UserCheck(item.Id) == HttpStatusCode.BadRequest) {
				item.AccessToken = null;
				return HttpStatusCode.BadRequest;
			}

			if (PassCheck(item.AccessToken) == HttpStatusCode.BadRequest) {
				item.AccessToken = null;
				return HttpStatusCode.BadRequest;
			}
			return HttpStatusCode.OK;
		}

		private static HttpStatusCode UserCheck(string userid) {
			return userid.Equals("root") ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
		}
		
		private static HttpStatusCode PassCheck(string password) {
			return password.Equals("password") ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
		}
		
		[HttpGet("createAccount")]
		public ActionResult<CaResult> CreateAccount(string id, string password, string email, string psCheck, string emCheck) {
			CaResult result = new CaResult {Id = id, Password = password, EMail = email};
			if (password.Equals(psCheck) || email.Equals(emCheck)) {
				Response.StatusCode = 400;
			}
			
			return result;
		}

		public class CaResult {

			public string Id { get; set; } = string.Empty;

			public string Password { get; set; } = string.Empty;

			public string EMail { get; set; } = string.Empty;

		}
	}
}