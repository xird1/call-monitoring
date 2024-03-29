using Newtonsoft.Json;
using TelusInternational.DataAccess.Context;
using TelusInternational.DataAccess.Entities;

namespace TelusInternational.DataAccess
{
    public  class DataInitializer
    {
        public static async Task SeedData(ApplicationDbContext context)
        {

            // this is just for testing, we usually store data in database, can make this configurable by defining json file name in .config
            if (!context.Users.Any())
            {
                string accountsJSON = File.ReadAllText("Data\\Account.json");
                List<User> accounts = JsonConvert.DeserializeObject<List<User>>(accountsJSON);
                await context.Users.AddRangeAsync(accounts);
            }
            if (!context.QueueGroups.Any())
            {
                string queueGroupsJSON = File.ReadAllText("Data\\QueueGroup.json");
                List<QueueGroup> queueGroups = JsonConvert.DeserializeObject<List<QueueGroup>>(queueGroupsJSON);
                await context.QueueGroups.AddRangeAsync(queueGroups);
            }
            if (!context.MonitorData.Any())
            {
                string monitorDataJSON = File.ReadAllText("Data\\MonitorData.json");
                List<MonitorData> monitorData = JsonConvert.DeserializeObject<List<MonitorData>>(monitorDataJSON);
                await context.MonitorData.AddRangeAsync(monitorData);
            }
            await context.SaveChangesAsync();
        }
    }
}
