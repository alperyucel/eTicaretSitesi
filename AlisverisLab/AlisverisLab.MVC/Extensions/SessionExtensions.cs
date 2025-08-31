using Newtonsoft.Json;

namespace AlisverisLab.MVC.Extensions
{
	public static class SessionExtensions
	{
		public static void SetSession<T>(this ISession session, string key, T value)
		{
			var jsonValue = JsonConvert.SerializeObject(value);

			session.SetString(key, jsonValue);
		}

		public static T GetSession<T>(this ISession session, string key)
		{
			string jsonValue = session.GetString(key);

			return jsonValue == null ? default : JsonConvert.DeserializeObject<T>(jsonValue);
		}

		public static void RemoveSession(this ISession session, string key)
		{
			session.Remove(key);
		}
	}
}
