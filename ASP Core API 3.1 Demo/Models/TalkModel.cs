using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ASP_Core_API_3._1_Demo.Models;

namespace ASP_Core_API_3._1_Demo.Model
{
    public class TalkModel
    {
        public int talkId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000),MinLength(15)]
        public string Abstract { get; set; }
        [Range(100,300)]
        public int Level { get; set; }
        public SpeakerModel Speaker { get; set; }
    }
}
