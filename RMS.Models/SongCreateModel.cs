using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Models
{
    public class SongCreateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public override string ToString() => Title;
    }
}
