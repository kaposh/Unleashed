using System.Net;

namespace APIClient
{
	public class ApiResponse
	{
		/// <summary>
		/// Content of API response
		/// </summary>
		public string Content { get; set; }
		/// <summary>
		/// API response status code
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }
	}
}
