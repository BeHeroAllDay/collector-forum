using System;

namespace collector_forum.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
