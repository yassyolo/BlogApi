﻿namespace BlogAPI.Models.DTO
{
    public class BlogIndexDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
    }
}
