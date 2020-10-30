using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    public class Menu_Repo
    {
        private List<Meals> _menuContent = new List<Meals>();
        //add
        public bool AddContentMenu(Meals content)
        {
            int startingCount = _menuContent.Count;

            _menuContent.Add(content);

            bool wasAdded = (_menuContent.Count > startingCount) ? true : false;

            return wasAdded;
        }
        //Needed to you can select one to delete
        public Meals GetMealByName(string mealName)
        {
            foreach (Meals content in _menuContent)
            {
                if (content.MealName == mealName)
                {
                    return content;
                }
            }
            return null;
        }
        //delete
        public bool DeleteExistingMeal(Meals existingMeal)
        {
            bool deleteResult = _menuContent.Remove(existingMeal);
            return deleteResult;
        }
        //see all items
        public List<Meals> GetMeals()
        {
            return _menuContent;
        }
    }
}
