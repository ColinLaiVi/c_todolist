Console.WriteLine("Hello!");

List<string> TODOs = new List<string>();
bool exit = false;

do
{
	Console.WriteLine(" ");
	Console.WriteLine("What do you want to do?");
	Console.WriteLine("[S]ee all TODOs");
	Console.WriteLine("[A]dd a TODO");
	Console.WriteLine("[R]emove a TODO");
	Console.WriteLine("[E]xit");
	Console.WriteLine(" ");

	string userSelected = Console.ReadLine().ToUpper();

	switch (userSelected)
	{
		case "S":
			if (TODOs.Count <= 0)
			{
				Console.WriteLine("No TODOs have been added yet.");
			}
			else
			{
				for (int i = 1; i <= TODOs.Count; i++)
				{
					Console.WriteLine(i.ToString() + ". " + TODOs[i - 1]);
				}
			}
			break;
		case "A":
			string TODOadded;

			do
			{
				Console.WriteLine(" ");
				Console.WriteLine("Enter the TODO description:");
				string userInput = Console.ReadLine();
				TODOadded = userInput;

				if (string.IsNullOrEmpty(TODOadded) || TODOs.Contains(TODOadded))
				{
					Console.WriteLine("No TODO is added.");
				}
			} while (string.IsNullOrEmpty(TODOadded) || TODOs.Contains(TODOadded));

			TODOs.Add(TODOadded);
			Console.WriteLine("TODO successfully added: " + TODOadded);
			break;
		case "R":
			if (TODOs.Count <= 0)
			{
				Console.WriteLine("No TODOs have been added yet.");
			}
			else
			{
				bool removeFinished = false;

				do
				{
					Console.WriteLine(" ");
					Console.WriteLine("Select the index of the TODO you want to remove:");

					for (int i = 1; i <= TODOs.Count; i++)
					{
						Console.WriteLine(i.ToString() + ". " + TODOs[i - 1]);
					}

					string userInput = Console.ReadLine();

					if (string.IsNullOrEmpty(userInput))
					{
						Console.WriteLine("Selected index cannot be empty.");
					}
					else
					{
						bool isInt = int.TryParse(userInput, out int selectedIndex);

						if (isInt && ((selectedIndex - 1) < TODOs.Count) && (selectedIndex > 0))
						{
							string theRemovedTODO = TODOs[selectedIndex - 1];

							TODOs.Remove(TODOs[selectedIndex - 1]);

							Console.WriteLine("TODO removed: " + theRemovedTODO);

							removeFinished = true;
						}
						else
						{
							Console.WriteLine("The given index is not valid.");
						}
					}
				} while (!removeFinished);
			}
			break;
		case "E":
			exit = true;
			break;
		default:
			Console.WriteLine("Incorrect input");
			break;
	}
}
while (!exit);