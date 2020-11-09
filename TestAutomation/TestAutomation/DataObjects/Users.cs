
namespace TestAutomation.DataObjects
{
	class Users
	{
		public User Bohdan => new User { UserName = "qa-bohdan@unl.sh", Password = "TestPassword1" };
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
