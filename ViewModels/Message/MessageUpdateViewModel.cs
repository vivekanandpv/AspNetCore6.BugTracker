﻿using System.ComponentModel.DataAnnotations;

namespace AspNetCore6.BugTracker.ViewModels.Message;

public class MessageUpdateViewModel
{
    [Required]
    [MaxLength(500)]
    public string MessageDescription { get; set; }

    [Required]
    public bool IsResolved { get; set; }
}