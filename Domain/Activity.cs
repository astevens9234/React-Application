// Entity or Model for Activities.
// Class name relates to a table, each property relates to a column.

using System;

namespace Domain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Your program's entry point
        }
    }

    public class Activity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
    }
}
