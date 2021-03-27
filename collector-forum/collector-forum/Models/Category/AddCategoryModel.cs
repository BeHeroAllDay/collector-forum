﻿using Microsoft.AspNetCore.Http;

namespace collector_forum.Models.Category
{
    public class AddCategoryModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public IFormFile ImageUpload { get; set; }
    }
}
