using System;
namespace Database
{
    public class Bird
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public bool IsFavorite { get; set; }

        public Bird(string Location = "Berlin", bool IsFavorite = false)
        {
            this.Date = GetTodayDate();
            this.Location = Location;
            this.IsFavorite = IsFavorite;
        }
        public static DateTime GetTodayDate()
        {
            DateTime dateTime = DateTime.Today;
            return dateTime;
        }
    }

}



