using _04_Company_Outings_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Program
{
    public class ProgramUI
    {
        private Outings_Repo _repo = new Outings_Repo();
        public void Run()
        {
            Seed();
            Menu();
        }

        public void Seed()
        {
            _repo.AddOutings(new Outings(EventType.Bowling, 2, new DateTime(2018, 10, 1), 10));
            _repo.AddOutings(new Outings(EventType.Amusement_Park, 15, new DateTime(2015, 12, 25), 20));
            _repo.AddOutings(new Outings(EventType.Amusement_Park, 10, new DateTime(2010, 5, 1), 100));
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Display all outings\n" +
                    "2. Add an outing\n" +
                    "3. See the cost of all outings\n" +
                    "4. See the cost of outing by type\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Display all outings
                        ShowAllOutings();
                        break;
                    case "2":
                        //Add an Outing
                        AddOuting();
                        break;
                    case "3":
                        //See the cost of all outings
                        CostOfAllOutings();
                        break;
                    case "4":
                        //See the cost of outing by type
                        CostOfOutingsByType();
                        break;
                    case "5":
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

        private void ShowAllOutings()
        {
            Console.Clear();
            List<Outings> entireMenu = _repo.GetOutings();

            foreach (Outings content in entireMenu)
            {
                Console.WriteLine($"Event Type: {content.EventType.ToString().Replace("_", " ")}");
                Console.WriteLine($"People Attended: {content.PeopleAttended}");
                Console.WriteLine($"Date: {content.DateOfEvent}");
                Console.WriteLine($"Price per person: ${content.CostPerPerson}");
                Console.WriteLine($"Total Cost of Outing: ${content.TotalCostOfOuting}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to menu interface");
            Console.ReadKey();
        }

        private void AddOuting()
        {
            Console.Clear();
            string eventTypes = "";
            int markerNum = 1;
            foreach (string content in _repo.GetEventTypes())
            {
                eventTypes += $"{markerNum}. {content.Replace("_", " ")}\n";
                markerNum++;
            }
            Console.WriteLine(eventTypes);
            Console.WriteLine("Please chose a number by the event type from the list above");
            EventType newEventType = (EventType)Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("How many people attended the event?");
            int newPeopleAttended = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Enter the year(xxxx) this event took place");
            int newYearOfEvent = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month(XX) numericaly this event took place");
            int newMonthOfEvent = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day(xx) of the month this event took place?");
            int newDayOfEvent = Int32.Parse(Console.ReadLine());
            DateTime newDateOfEvent = new DateTime(newYearOfEvent, newMonthOfEvent, newDayOfEvent);
            Console.Clear();

            Console.WriteLine("Please enter how much it cost per person at this event");
            double newCostPerPerson = double.Parse(Console.ReadLine());

            bool addSuccess = _repo.AddOutings(new Outings(newEventType, newPeopleAttended, newDateOfEvent, newCostPerPerson));
            if (addSuccess == true)
            {
                Console.WriteLine("Outing succesfuly added!");
            }
            else
            {
                Console.WriteLine("Oh No! Something went worng!");
            }
            Console.ReadKey();
        }
        public void CostOfAllOutings()
        {
            Console.Clear();
            Console.WriteLine($"Total cost of all outings: ${_repo.GetTotalCosts()}");
            Console.ReadKey();
        }
        public void CostOfOutingsByType()
        {
            Console.Clear();
            string eventTypes = "";
            int markerNum = 1;
            foreach (string content in _repo.GetEventTypes())
            {
                eventTypes += $"{markerNum}. {content.Replace("_", " ")}\n";
                markerNum++;
            }
            Console.WriteLine(eventTypes);
            Console.WriteLine("Please chose a number by the event type from the list above to get its cost");
            EventType newEventType = (EventType)Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine($"Total cost of {newEventType.ToString().Replace("_", " ")} outings: ${_repo.GetCostByEventType(newEventType)}");
            Console.ReadKey();
        }
    }
}
