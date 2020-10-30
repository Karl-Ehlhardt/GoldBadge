using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Company_Outings_Repo
{
    public class Outings
    {
        public EventType EventType { get; set; }
        public int PeopleAttended { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCostOfOuting 
        { 
            get
            {
                return PeopleAttended * CostPerPerson;
            } 
        }
        public Outings()
        {

        }
        public Outings(EventType eventType, int peopleAttended, DateTime dateOfEvent, double costPerPerson)
        {
            EventType = eventType;
            PeopleAttended = peopleAttended;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
        }

    }
    public enum EventType
    {
        Golf = 1,
        Bowling,
        Amusement_Park,
        Concert,
    }
}
