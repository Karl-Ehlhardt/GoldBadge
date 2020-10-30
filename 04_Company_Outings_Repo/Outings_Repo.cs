using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Company_Outings_Repo
{
    public class Outings_Repo
    {
        private List<Outings> _eventsContent = new List<Outings>();
        //add
        public bool AddOutings(Outings content)
        {
            int startingCount = _eventsContent.Count;

            _eventsContent.Add(content);

            bool wasAdded = (_eventsContent.Count > startingCount) ? true : false;

            return wasAdded;
        }
        //Get all outings
        public List<Outings> GetOutings()
        {
            return _eventsContent;
        }
        //Needed to list the events is the list ever changes
        public List<string> GetEventTypes()
        {
            return Enum.GetNames(typeof(EventType)).ToList();
        }
        public double GetTotalCosts()
        {
            double totalCost = 0;
            foreach(Outings content in _eventsContent)
            {
                totalCost += content.TotalCostOfOuting;
            }
            return totalCost;
        }
        public double GetCostByEventType(EventType eventType)
        {
            double totalCost = 0;
            foreach (Outings content in _eventsContent)
            {
                if ((content.EventType).ToString().ToLower() == eventType.ToString().ToLower())
                {
                totalCost += content.TotalCostOfOuting;
                }
            }
            return totalCost;
        }
    }
}

