using System.Net;

namespace APIClient
{
	public class ApiResponse
	{
		public string Content { get; set; }
		public HttpStatusCode StatusCode { get; set; }
	}
}
