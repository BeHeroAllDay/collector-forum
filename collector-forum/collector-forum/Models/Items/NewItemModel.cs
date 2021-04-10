using System;

namespace collector_forum.Models.Items
{
    public class NewItemModel
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public DateTime Updated { get; set; }
        public DateTime Added { get; set; }
    }
}
