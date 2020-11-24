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
		public ActionResult<AccountItem> Get(string request) {
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
				return HttpStatusCode.BadRequest;
			}
			return HttpStatusCode.OK;
		}
	}
}