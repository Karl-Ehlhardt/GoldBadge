using _01_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Program
{
    class ProgramUI
    {
        private Menu_Repo _repo = new Menu_Repo();
        public void Run()
        {
            Seed();
            Menu();
        }

        public void Seed()
        {
        _repo.AddContentMenu(new Meals (1, "Duck", "Comes with fries", new List<string> { "Duck", "Fries" }, 40.20));
        _repo.AddContentMenu(new Meals (2, "Mutton", "Comes with fries", new List<string> { "Mutton", "Fries" }, 40.20));
        _repo.AddContentMenu(new Meals (3, "Snake", "Comes with fries", new List<string> { "Snake", "Fries" }, 40.20));
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Display all menu items\n" +
                    "2. Add meal to menu\n" +
                    "3. Remove meal from menu\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Display all menu items
                        ShowEntireMenu();
                        break;
                    case "2":
                        //Add a Meal
                        AddMeal();
                        break;
                    case "3":
                        //Remove meal from menu
                        RemoveMeal();
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

        private void ShowEntireMenu()
        {
            Console.Clear();
            List<Meals> entireMenu = _repo.GetMeals();

            foreach (Meals content in entireMenu)
            {
                Console.WriteLine($"Number: {content.MealNum}");
                Console.WriteLine($"Name: {content.MealName}");
                Console.WriteLine($"Description: {content.Description}");
                Console.WriteLine("Ingredients: {0}", string.Join(", ", content.Ingredients));
                Console.WriteLine($"Price: ${content.Price}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to menu interface");
            Console.ReadKey();
        }
        private void AddMeal()
        {
            Console.Clear();
            List<string> newIngredients = new List<string>();
            string mealNumbers = "";
            string mealNames = "";
            foreach (Meals content in _repo.GetMeals())
            {
                mealNumbers += $" | {content.MealNum}";
                mealNames += $" | {content.MealName}";
            }

            Console.WriteLine($"Meal numbers in use {mealNumbers}");
            Console.WriteLine("Please enter a meal number (1 and above):");
            int newMealNum = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine($"Meal names in use {mealNames}");
            Console.WriteLine("Please enter a meal name:");
            string newMealName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter a meal description:");
            string newDescription = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter ingredents one at a time:");
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
                    newIngredients.Add(input);
                    Console.WriteLine("Ingredients so far: {0}", string.Join(", ", newIngredients));
                    Console.WriteLine("Enter another ingredent or press enter to move on");
                    input = Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.Clear();

            Console.WriteLine("Please enter a meal price ($0.01 and above):");
            double newPrice = double.Parse(Console.ReadLine());

            bool addSuccess = _repo.AddContentMenu(new Meals(newMealNum, newMealName, newDescription, newIngredients, newPrice));
            if (addSuccess == true)
                {
                    Console.WriteLine("Meal succesfuly added!");
                }
            else
            {
                Console.WriteLine("Oh No! Something went worng!");
            }
            Console.ReadKey();
        }
        private void RemoveMeal() 
        {
            Console.Clear();

            List<Meals> listOfContent = _repo.GetMeals();

            foreach (Meals content in listOfContent)
            {
                Console.WriteLine($"Number: {content.MealNum} Name:{content.MealName}");
            }
            Console.WriteLine("Enter the meal name you'd like to delete! Capitalization counts!");

            string mealName = Console.ReadLine();

            Meals toBeDeletedMeal = _repo.GetMealByName(mealName);

            if (toBeDeletedMeal != null)
            {
                bool wasDeleted = _repo.DeleteExistingMeal(toBeDeletedMeal);
                if (wasDeleted == true)
                {
                    Console.WriteLine("Meal succufuly deleted!");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong, meal NOT removed!");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find result!");
            }
            Console.ReadKey();
        }


    }
}
