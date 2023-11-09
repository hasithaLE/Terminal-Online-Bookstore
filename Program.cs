using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Online_Bookstore
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SqlConnection sqlConnection;
			string connectionString = @"Data Source=LAPTOP-J0D0MHPD\SQLSERVERNEW;Initial Catalog=onlineBookstore;Integrated Security=True";
			
			sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();

			Console.WriteLine("...Welcome to Online Bookstore...");
			Console.WriteLine("Press 1 for Log In\nPress 2 for Register\nPress 3 for Skip and Go to Store");
			string inputOne = Console.ReadLine();
			if (inputOne == "1")
			{
				Console.WriteLine($"Enter Username and Password");
				Console.Write($"username: ");
				string uName = Console.ReadLine();
				Console.Write($"password: ");
				string pWord = Console.ReadLine();

				string usernameQuery = $"SELECT username,password FROM logins WHERE username = @UserName;";

				SqlCommand uNameSqlCommand = new SqlCommand(usernameQuery,sqlConnection);
				uNameSqlCommand.Parameters.AddWithValue("@UserName", uName);
				SqlDataReader reader = uNameSqlCommand.ExecuteReader();

				if (reader.Read())
				{
					Console.WriteLine(uName);
					string usrnme = reader[0].ToString();
					Console.WriteLine(usrnme);
					Console.WriteLine(String.Equals(usrnme, uName, StringComparison.OrdinalIgnoreCase));
					Console.WriteLine(pWord);
					Console.WriteLine(reader[1].ToString());
					if (uName == reader[0].ToString() && pWord == reader[1].ToString())
					{
						Console.WriteLine($"Login Success!\nHi {uName}, Welcome!");
					}
                    else
                    {
						Console.WriteLine("invalid username or password");
                    }
                }
                else
                {
					Console.WriteLine("invalid username or password");
                }
                reader.Close();
				sqlConnection.Close();
			}
			else if (inputOne == "2")
			{
				Console.WriteLine($"Enter Username and Password");
				Console.Write($"username: ");
				string uName = Console.ReadLine();
				Console.Write($"password: ");
				string pWord = Console.ReadLine();

				string insertQuery = "INSERT INTO logins(username,password) VALUES('"+uName+"','"+pWord+"')";
				SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection);
				sqlCommand.ExecuteNonQuery();

				Console.WriteLine("Added");
				sqlConnection.Close();
				//Console.WriteLine($"Enter Your Fullname, Unique Username and Strong Password");
			}
			else if (inputOne == "3") 
			{
				Console.WriteLine($"Welcome to the Store");
			}
			else
			{
				Console.WriteLine($"Default");
			}

        }
	}
}