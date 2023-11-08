using System.Data;
using System.Data.SqlClient;

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

				string usernameQuery = "SELECT username FROM logins WHERE username = '"+uName+"';";
				string passwordQuery = "SELECT password FROM logins WHERE username = '"+uName+"';";

				SqlCommand uNameSqlCommand = new SqlCommand(usernameQuery,sqlConnection);

				SqlDataReader reader1 = uNameSqlCommand.ExecuteReader();
				Console.WriteLine(reader1.GetValue(1).ToString());
				//string uNameCheck = reader1.GetValue(1).ToString();
				reader1.Close();

				SqlCommand pWordSqlCommand = new SqlCommand(passwordQuery, sqlConnection);

				SqlDataReader reader2 = pWordSqlCommand.ExecuteReader();
				Console.WriteLine(reader2.GetValue(1).ToString());
				//string pWordCheck = reader2.GetValue(1).ToString();
				reader2.Close();

				//if (uNameCheck != null || uNameCheck != "" )
				//{
				//	if (uName == uNameCheck && pWord == pWordCheck)
				//	{
				//		Console.WriteLine("Hi, Welcome "+ uNameCheck);
				//	}
    //                else
    //                {
				//		Console.WriteLine("Incorrect username or password.");
    //                }
    //            }
    //            else
    //            {
				//	Console.WriteLine("Not a registered user.");
    //            }


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