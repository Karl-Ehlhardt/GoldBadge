using System;
using System.Collections.Generic;
using _03_Badges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Badges_Repo _repo = new Badges_Repo();
        [TestMethod]
        public void AddAndRecallBadge()
        {
            _repo.AddBadge(new Badge(1, new List<string> { "gg", "aa" }));
            _repo.AddBadge(new Badge(2, new List<string> { "ff", "dd" }));
            Badge test = _repo.GetContentByBadgeID(1);
            Console.WriteLine(test.BadgeID);
            foreach (string access in test.Access)
            {
                Console.WriteLine(access);
            }
        }
        [TestMethod]
        public void DictionaryTest()
        {
            _repo.AddBadge(new Badge(1, new List<string> { "gg", "aa" }));
            _repo.AddBadge(new Badge(2, new List<string> { "ff", "dd" }));
            Dictionary<int, List<string>> test = _repo.MakeDictionaryOfBadges();
            foreach (KeyValuePair<int, List<string>> content in test)
            {
                Console.WriteLine("Key: {0}", content.Key);//Key is the left value and Value is the right
                foreach (string access in content.Value)
                {
                    Console.WriteLine("Access modifier: {0}",  access);
                }
            }
        }
        [TestMethod]
        public void UpdateBadgeTest()
        {
            _repo.AddBadge(new Badge(1, new List<string> { "gg", "aa" }));
            _repo.AddBadge(new Badge(2, new List<string> { "ff", "dd" }));

            _repo.UpdateBadge(1, new Badge(1, new List<string> { "44", "66" }));

            Dictionary<int, List<string>> test = _repo.MakeDictionaryOfBadges();
            foreach (KeyValuePair<int, List<string>> content in test)
            {
                Console.WriteLine("Key: {0}", content.Key);
                foreach (string access in content.Value)
                {
                    Console.WriteLine("Access modifier: {0}", access);
                }
            }
        }
    }
}
