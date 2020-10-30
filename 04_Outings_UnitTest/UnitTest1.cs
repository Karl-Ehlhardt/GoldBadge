using System;
using System.Collections.Generic;
using _04_Company_Outings_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Outings_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Outings_Repo _repo = new Outings_Repo();
        [TestMethod]
        public void AddAndDisplayTests()
        {
            _repo.AddOutings(new Outings(EventType.Bowling, 20, DateTime.Now, 10));
            _repo.AddOutings(new Outings(EventType.Concert, 10, DateTime.Now, 10));
            List<Outings> listOfOutings = new List<Outings>(_repo.GetOutings());
            foreach (Outings content in listOfOutings)
            {
                Console.WriteLine($"Event Type: {content.EventType}");
            }
        }
        [TestMethod]
        public void TotalCostAndByEventCost()
        {
            _repo.AddOutings(new Outings(EventType.Bowling, 20, DateTime.Now, 10));
            _repo.AddOutings(new Outings(EventType.Concert, 10, DateTime.Now, 10));
            Console.WriteLine($"Total Costs: {_repo.GetTotalCosts()}");
            Console.WriteLine($"By Type: {_repo.GetCostByEventType(EventType.Bowling)}");
        }


        [TestMethod]
        public void ListEvents()
        {
            Console.WriteLine(string.Join(", ", _repo.GetEventTypes()));
            
        }
    }
}
