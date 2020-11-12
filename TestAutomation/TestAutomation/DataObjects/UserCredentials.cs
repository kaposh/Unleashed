
namespace TestAutomation.DataObjects
{
	class UserCredentials
	{
		public User Bohdan => new User { UserName = "qa+bohdan@unl.sh", Password = "TestPassword1" };
		/// <summary>
		/// Get user by property name
		/// </summary>
		/// <param name="userName">Name of user to be returned</param>
		/// <returns></returns>
		public User GetUser(string userName)
		{
			return (User)GetType().GetProperty(userName).GetValue(this, null);
		}
	}

	class User
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}

}
