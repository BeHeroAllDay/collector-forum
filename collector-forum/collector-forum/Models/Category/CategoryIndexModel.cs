using System.Collections.Generic;

namespace collector_forum.Models.Category
{
    public class CategoryIndexModel
    {
        public IEnumerable<CategoryListingModel> CategoryList { get; set; }
    }
}
