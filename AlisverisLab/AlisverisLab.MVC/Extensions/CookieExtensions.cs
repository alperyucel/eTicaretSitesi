using Newtonsoft.Json;

namespace AlisverisLab.MVC.Extensions
{
	public static class CookieExtensions
	{
		public static void SetCookie<T>(this IResponseCookies cookies, string key, T value, DateTime? expires = null)
		{

			string data = JsonConvert.SerializeObject(value);

			var option = new CookieOptions
			{
				HttpOnly = true,
				Secure = true,
				SameSite = SameSiteMode.Strict,
				Expires = expires ?? DateTimeOffset.UtcNow.AddDays(1)

			};

			cookies.Append(key, data, option);

		}


		public static T GetCookie<T>(this IRequestCookieCollection cookies, string key)
		{
			cookies.TryGetValue(key, out var jsonValue);
			return jsonValue == null ? default : JsonConvert.DeserializeObject<T>(jsonValue);
		}

		public static void DeleteCookie(this IResponseCookies cookies, string key)
		{
			cookies.Delete(key);
		}
	}
}
