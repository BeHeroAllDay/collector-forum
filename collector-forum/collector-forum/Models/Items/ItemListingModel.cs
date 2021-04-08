using collector_forum.Models.Category;
using System;

namespace collector_forum.Models.Items
{
    public class ItemListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
    }
}
