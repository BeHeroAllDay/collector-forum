using System;
using System.Collections;
using System.Collections.Generic;

namespace collector_forum.Models.Items
{
    public class ItemIndexModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public DateTime Added { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
