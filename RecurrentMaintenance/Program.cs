using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrentMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {

            Process_NotEnding_Maintenances();
            Console.ReadLine();

        }

        private static void Process_NotEnding_Maintenances()
        {
            //Select * from EquipmentRecurrentMaintenance where Deleted = 0 and IsCompleted = 0 and IsNeverEnding = 1 
            //long lastScheduledMaintenanceId = Select top 1 Id from ScheduledMaintenance order by Id desc where Deleted = 0 and EquipmentRecurrentMaintenanceId = 1
            long? lastScheduledMaintenanceId = null;

            bool isNewMaintenance = lastScheduledMaintenanceId == null || lastScheduledMaintenanceId == 0;

            if (isNewMaintenance)
            {
                Generate_First_NotEnding_Maintenance_Serie();
            }
            else
            {
                Generate_Next_NotEnding_Maintenance_Serie();
            }
        }

        private static void Generate_First_NotEnding_Maintenance_Serie()
        {
            //Start Date
            DateTime startDate = new DateTime(2023, 7, 4);

            int totalMonths = 1;

            string maintenancePeriod = "weekly"; // hourly, weekly, or monthly

            TimeSpan maintenanceInterval;
            // Calculate the time span based on the maintenance period

            if (maintenancePeriod.Equals("hourly", StringComparison.OrdinalIgnoreCase))
                maintenanceInterval = TimeSpan.FromHours(1);
            else if (maintenancePeriod.Equals("weekly", StringComparison.OrdinalIgnoreCase))
                maintenanceInterval = TimeSpan.FromDays(7);
            else if (maintenancePeriod.Equals("monthly", StringComparison.OrdinalIgnoreCase))
                maintenanceInterval = TimeSpan.FromDays(30); // Approximation, adjust as needed
            else
            {
                maintenanceInterval = TimeSpan.FromDays(7);
            }

            // Calculate the end date by adding the total months to the start date
            DateTime endDate = startDate.AddMonths(totalMonths);
            Console.WriteLine("Start Date: " + startDate.Date.ToString());
            Console.WriteLine("Frequency: " + maintenancePeriod + " (" + maintenanceInterval.Days.ToString() + " days)");
            Console.WriteLine("End after : " + totalMonths + " month(s)");
            Console.WriteLine("Calculated End Date: " + endDate.Date.ToString());

            // Generate the maintenance dates
            int totalMaintenances = 0;
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                // Perform maintenance action for the current date
                Console.WriteLine("\nMaintenance Date: " + currentDate);

                // Move to the next maintenance date
                currentDate += maintenanceInterval;

                totalMaintenances++;
            }

            Console.WriteLine("\nTotal maintenance dates generated: " + totalMaintenances);
        }

        private static void Generate_Next_NotEnding_Maintenance_Serie()
        {
            //Last Maintenance Date
            DateTime lastDate = new DateTime(2023, 8, 1);
            
            int totalMonths = 1;

            string maintenancePeriod = "weekly"; // hourly, weekly, or monthly

            TimeSpan maintenanceInterval;
            // Calculate the time span based on the maintenance period

            if (maintenancePeriod.Equals("hourly", StringComparison.OrdinalIgnoreCase))
                maintenanceInterval = TimeSpan.FromHours(1);
            else if (maintenancePeriod.Equals("weekly", StringComparison.OrdinalIgnoreCase))
                maintenanceInterval = TimeSpan.FromDays(7);
            else if (maintenancePeriod.Equals("monthly", StringComparison.OrdinalIgnoreCase))
                maintenanceInterval = TimeSpan.FromDays(30); // Approximation, adjust as needed
            else
            {
                maintenanceInterval = TimeSpan.FromDays(7);
            }

            //Calculate the start date
            DateTime startDate = lastDate + maintenanceInterval;

            // Calculate the end date by adding the total months to the start date
            DateTime endDate = startDate.AddMonths(totalMonths);
            Console.WriteLine("Start Date: " + startDate.Date.ToString());
            Console.WriteLine("Frequency: " + maintenancePeriod + " (" + maintenanceInterval.Days.ToString() + " days)");
            Console.WriteLine("End after : " + totalMonths + " month(s)");
            Console.WriteLine("Calculated End Date: " + endDate.Date.ToString());

            // Generate the maintenance dates
            int totalMaintenances = 0;
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                // Perform maintenance action for the current date
                Console.WriteLine("\nMaintenance Date: " + currentDate);

                // Move to the next maintenance date
                currentDate += maintenanceInterval;

                totalMaintenances++;
            }

            Console.WriteLine("\nTotal maintenance dates generated: " + totalMaintenances);
        }
    }
}
