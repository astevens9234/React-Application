using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Activities.Any()) return;

            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "Morning Yoga Session",
                    Date = new DateTime(2024, 9, 1, 7, 30, 0),
                    Description = "A refreshing morning yoga session to start the day.",
                    Category = "Health & Wellness",
                    City = "New York",
                    Venue = "Central Park"
                },
                new Activity
                {
                    Title = "Tech Conference 2024",
                    Date = new DateTime(2024, 11, 15, 9, 0, 0),
                    Description = "Annual technology conference featuring keynote speakers and workshops.",
                    Category = "Technology",
                    City = "San Francisco",
                    Venue = "Moscone Center"
                },
                new Activity
                {
                    Title = "Art Exhibition - Modern Masters",
                    Date = new DateTime(2024, 10, 5, 18, 0, 0),
                    Description = "Exhibition showcasing modern art masterpieces.",
                    Category = "Art & Culture",
                    City = "Chicago",
                    Venue = "Art Institute of Chicago"
                },
                new Activity
                {
                    Title = "Music Festival 2024",
                    Date = new DateTime(2024, 8, 24, 12, 0, 0),
                    Description = "A full-day music festival featuring various artists and genres.",
                    Category = "Music",
                    City = "Los Angeles",
                    Venue = "LA Coliseum"
                },
                new Activity
                {
                    Title = "Business Networking Event",
                    Date = new DateTime(2024, 12, 3, 19, 0, 0),
                    Description = "An opportunity to network with business professionals from various industries.",
                    Category = "Business",
                    City = "Seattle",
                    Venue = "Seattle Convention Center"
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}