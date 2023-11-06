namespace Online_Bookstore
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("...Welcome to Online Bookstore...");
			Console.WriteLine("Press 1 for Log In\nPress 2 for Register\nPress 3 for Skip and Go to Store");
			string inputOne = Console.ReadLine();
			if (inputOne == "1")
			{
				Console.WriteLine($"Enter Username and Password");
			}
			else if (inputOne == "2")
			{
				Console.WriteLine($"Enter Your Fullname, Unique Username and Strong Password");
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