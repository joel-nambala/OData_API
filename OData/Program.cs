using BC;
using Microsoft.OData.Client;

namespace OData
{
    class Program
    {
        static void Main(string[] args)
        {
            string company = "MNU";
            var serviceRoot = $"http://joel:6048/MNU/ODataV4/Company('{company}')/";
            var context = new BC.NAV(new Uri(serviceRoot));
            context.BuildingRequest += Context_BuildingRequest;

            // Add data to BC
            //var coa = BC.Chart_of_Accounts.CreateChart_of_Accounts("10");
            //coa.Name = "Demo test from a console applications";
            //context.AddToChart_of_Accounts(coa);
            //context.SaveChanges();

            //var data = context.Chart_of_Accounts.AddQueryOption("$filter=No eq 10002");
            var data = context.Chart_of_Accounts.Where(u => u.No == "10002");

            foreach (var item in data)
            {
                Console.WriteLine($"{item.No}: {item.Name} {item.Net_Change}");
            }
        }

        private static void Context_BuildingRequest(object sender, Microsoft.OData.Client.BuildingRequestEventArgs e)
        {
            e.Headers.Add("Authorization", "Basic am9lbDpKb2VsQDIwMjM=");
        }
    }
}