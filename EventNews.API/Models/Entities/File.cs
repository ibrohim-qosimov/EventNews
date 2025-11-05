using System;
using System.ComponentModel.DataAnnotations;

public class FileEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string Extension { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }