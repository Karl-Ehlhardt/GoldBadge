using System;
using System.Collections.Generic;
using _01_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Menu_Repo _repo = new Menu_Repo();
        [TestMethod]
        public void CanIAddAMeal()
        {
            Meals newMeal = new Meals(1, "Chicken", "It's Chicken", new List<string> { "element1", "element2", "element3" }, 40.20);


            bool wasAdded = _repo.AddContentMenu(newMeal);
            if (wasAdded == true)
            {
                Console.WriteLine("Meal succufuly added!");
            }
            else
            {
                Console.WriteLine("Oops something went wrong, Meal NOT added!");
            }


            foreach (Meals content in _repo.GetMeals())
            {
                Console.WriteLine(content.MealName);
            }
        }
        [TestMethod]
        public void AddMultipalMeals()
        {
            Meals newMeal = new Meals(1, "Chicken", "It's Chicken", new List<string> { "element1", "element2", "element3" }, 40.20);
            Meals newMeal2 = new Meals(1, "Beef", "It's Chicken", new List<string> { "element1", "element2", "element3" }, 40.20);
            Meals newMeal3 = new Meals(1, "Duck", "It's Chicken", new List<string> { "element1", "element2", "element3" }, 40.20);

            _repo.AddContentMenu(newMeal2);
            _repo.AddContentMenu(newMeal3);
            _repo.AddContentMenu(newMeal);

            foreach (Meals content in _repo.GetMeals())
            {
                Console.WriteLine(content.MealName);
            }
        }
        [TestMethod]
        public void DeleteMealsAndLookupMealsAndDisplayMeals()
        {
            Meals newMeal = new Meals(1, "Chicken", "It's Chicken", new List<string> { "element1", "element2", "element3" }, 40.20);
            Meals newMeal2 = new Meals(1, "Beef", "It's Chicken", new List<string> { "element1", "element2", "element3" }, 40.20);
            _repo.AddContentMenu(newMeal);
            _repo.AddContentMenu(newMeal2);
            List<Meals> current = _repo.GetMeals();
            foreach (Meals content in _repo.GetMeals())
            {
                Console.WriteLine(content.MealName);
            }
            Meals removed = _repo.GetMealByName("Chicken");
            _repo.DeleteExistingMeal(removed);
            foreach (Meals content in _repo.GetMeals())
            {
                Console.WriteLine(content.MealName);
            }
        }
    }
}
