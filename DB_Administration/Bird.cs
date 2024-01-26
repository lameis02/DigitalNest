using System;
namespace Database
{
    public class Bird
    {
        public int ID { get; set; }
        public string Species { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public byte[] birdbytes { get; set; }
        public bool IsFavorite { get; set; }

       
    }

}



