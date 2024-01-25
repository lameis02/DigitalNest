using System;
namespace Database
{
    public class Bird
    {
        public string ID { get; set; }
        public string Species { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public byte[] birdbytes { get; set; }
        public bool IsFavorite { get; set; }

        public Bird()
        {
            this.ID = Guid.NewGuid().ToString();
        }
       
    }

}



