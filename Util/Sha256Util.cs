using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace WebAppCore.Util {
public static class Sha256Util {
	private static readonly SHA256CryptoServiceProvider HashProvider = new SHA256CryptoServiceProvider();

	public static string GetSha256HashedString(string value) {
		return string.Join("", HashProvider.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(x => $"{x:x2}"));
	}
}
}
