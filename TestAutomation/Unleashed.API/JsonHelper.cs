using Newtonsoft.Json;

namespace APIClient
{
	class JsonHelper
	{
		public static string Serialize(object objectToSrialize)
		{
			return JsonConvert.SerializeObject(objectToSrialize);
		}
	}
}
