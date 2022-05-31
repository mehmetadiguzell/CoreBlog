using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? RecevierID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }


        public Writer SenderUser { get; set; }
        public Writer RecevierUser { get; set; }
    }
}
