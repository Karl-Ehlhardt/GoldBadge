using _03_Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Program
{
    public class ProgramUI
    {
        private Badges_Repo _repo = new Badges_Repo();
        public void Run()
        {
            Seed();
            Menu();
        }

        public void Seed()
        {
            _repo.AddBadge(new Badge(1, new List<string> { "A1", "A8" }));
            _repo.AddBadge(new Badge(2, new List<string> { "A3", "D3" }));
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges and their access\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Display all outings
                        AddABadge();
                        break;
                    case "2":
                        //Add an Outing
                        EditABadge();
                        break;
                    case "3":
                        //See the cost of all outings
                        ListAllBadges();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void AddABadge()
        {
            Console.Clear();
            string currentIDs = "";
            foreach (KeyValuePair<int, List<string>> content in _repo.MakeDictionaryOfBadges())
            {
                currentIDs += $" | {content.Key}";
            }
            Console.WriteLine(currentIDs);
            Console.WriteLine("Please chose a new badge number, the ones above are alreay in use");
            int newBadgeID = Int32.Parse(Console.ReadLine());
            Console.Clear();

            List<string> enteredAccess = new List<string>();
            Console.WriteLine("Please enter the door access one at a time, press enter to give no access:");
            string input = Console.ReadLine();
            Console.Clear();

            while (input != "")
            {
                if (input == "")
                {
                    break;
                }
                else
                {
                    enteredAccess.Add(input);
                    Console.WriteLine("Doors able to be accessed so far: {0}", string.Join(", ", enteredAccess));
                    Console.WriteLine("Enter another door access or press enter to move on");
                    input = Console.ReadLine();
                    Console.Clear();
                }
            }
            List<string> newAccess = enteredAccess;
            Console.Clear();

            bool addSuccess = _repo.AddBadge(new Badge(newBadgeID, newAccess));
            if (addSuccess == true)
            {
                Console.WriteLine("Badge succesfuly added!");
            }
            else
            {
                Console.WriteLine("Oh No! Something went worng!");
            }

            Console.ReadKey();
        }
        private void EditABadge()
        {
            Console.Clear();
            List<string> currentBadges = new List<string>();
            foreach (KeyValuePair<int, List<string>> content in _repo.MakeDictionaryOfBadges())
            {
                currentBadges.Add(content.Key.ToString());
            }
            Console.WriteLine("{0}",string.Join(" | ", currentBadges));
            Console.WriteLine("Please chose which badge you'd like to edit");
            int badgeID = Int32.Parse(Console.ReadLine());
            Console.Clear();

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Badge ID Selected: {0}", badgeID);
                Console.WriteLine("What would you like to do?\n" +
                    "1.Add access to badge\n" +
                    "2.Remove access from badge");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // Display all outings
                        AddAccessToBadge(badgeID);
                        continueToRun = false;
                        break;
                    case "2":
                        //Add an Outing
                        RemoveAccessFromBadge(badgeID);
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }

            }
        private void ListAllBadges()
        {
            Console.Clear();

            foreach (KeyValuePair<int, List<string>> content in _repo.MakeDictionaryOfBadges())
            {
                Console.WriteLine("             Badge ID: {0}\nAccess for this badge: {1}", content.Key, string.Join(", ", content.Value.ToList()));
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to menu interface");
            Console.ReadKey();
        }

        private void AddAccessToBadge(int oldBadgeID)
        {
            Console.Clear();
            Badge oldBadge = _repo.GetContentByBadgeID(oldBadgeID);
            Console.WriteLine("Badge ID: {0}", oldBadge.BadgeID);
            Console.WriteLine("Doors this badge can currently access: {0}",string.Join(", ", oldBadge.Access.ToList()));

            List<string> finalAccess = oldBadge.Access.ToList();
            Console.WriteLine("Please enter the additional door access one at a time, press enter to do nothing:");
            string input = Console.ReadLine();
            Console.Clear();

            while (input != "")
            {
                if (input == "")
                {
                    break;
                }
                else
                {
                    finalAccess.Add(input);
                    Console.WriteLine("Doors able to be accessed so far: {0}", string.Join(", ", finalAccess));
                    Console.WriteLine("Enter another door access or press enter to finish");
                    input = Console.ReadLine();
                    Console.Clear();
                }
            }
            bool updateSuccess = _repo.UpdateBadge(oldBadgeID, new Badge(oldBadgeID, finalAccess));
        }
        private void RemoveAccessFromBadge(int oldBadgeID)
        {
            Console.Clear();
            Badge oldBadge = _repo.GetContentByBadgeID(oldBadgeID);
            Console.WriteLine("Badge ID: {0}", oldBadge.BadgeID);
            Console.WriteLine("Doors this badge can currently access: {0}", string.Join(", ", oldBadge.Access.ToList()));

            List<string> finalAccess = oldBadge.Access.ToList();
            Console.WriteLine("Type the doors you'd like to remove EXACTLY as written above");
            Console.WriteLine("Please enter the door to be removed one at a time, press enter to do nothing:");
            string input = Console.ReadLine();
            Console.Clear();

            while (input != "")
            {
                bool removed = finalAccess.Remove(input);
                if (input == "")
                {
                    break;
                }
                else if(removed)
                {
                    Console.WriteLine("Doors able to be accessed still: {0}", string.Join(", ", finalAccess));
                    Console.WriteLine("Type the doors you'd like to remove EXACTLY as written above");
                    Console.WriteLine("Enter another door to remove or press enter to finish");
                    input = Console.ReadLine();
                    Console.Clear();
                    removed = false;
                }
                else
                {
                    Console.WriteLine("That door is not currently accessible by this badge");
                    Console.WriteLine();
                    Console.WriteLine("Doors able to be accessed still: {0}", string.Join(", ", finalAccess));
                    Console.WriteLine("Type the doors you'd like to remove EXACTLY as written above");
                    Console.WriteLine("Enter another door to remove or press enter to finish");
                    input = Console.ReadLine();
                    Console.Clear();
                }
            }
            bool updateSuccess = _repo.UpdateBadge(oldBadgeID, new Badge(oldBadgeID, finalAccess));
        }
    }
}