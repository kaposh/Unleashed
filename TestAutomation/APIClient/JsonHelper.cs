using Newtonsoft.Json;

namespace APIClient
{
	class JsonHelper
	{
		/// <summary>
		/// Serialize any object
		/// </summary>
		/// <param name="objectToSrialize">Object to be serializes</param>
		/// <returns>Json string</returns>
		public static string Serialize(object objectToSrialize)
		{
			return JsonConvert.SerializeObject(objectToSrialize);
		}
	}
}
