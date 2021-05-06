using System.Security.AccessControl;

namespace ASP_Core_API_3._1_Demo.Data.Entities
{
    public class Talk
    {
           public int TalkId { get; set; }
           public Camp Camp { get; set; }
           public string Title { get; set; }
           public string Abstract { get; set; }
           public int Level { get; set; }
           public Speaker Speaker { get; set; }
    }
}
