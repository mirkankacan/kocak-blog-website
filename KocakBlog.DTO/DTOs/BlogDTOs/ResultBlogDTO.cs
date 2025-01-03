﻿using KocakBlog.DTO.DTOs.AppUserDTOs;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;

namespace KocakBlog.DTO.DTOs.BlogDTOs
{
    public class ResultBlogDTO
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ResultBlogCategoryDTO BlogCategory { get; set; }
        public ResultAppUser AppUser { get; set; }
    }
}