using System.Net;

namespace WebAppCore.Controllers.Account {
	/// <summary>
	/// ログイン情報
	/// </summary>
	public class AccountItem {
		/// <summary>
		/// ログインID
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// アクセストークン
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		/// ステータスコード
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }
	}
}