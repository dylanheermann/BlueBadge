﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Models
{
    public class SongListModel
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public string Link { get; set; }

        public override string ToString() => $"[{SongId}] {Title}";
    }
}
