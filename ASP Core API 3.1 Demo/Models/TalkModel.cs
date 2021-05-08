using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public SpeakerModel Speaker { get; set; }
    }
}
