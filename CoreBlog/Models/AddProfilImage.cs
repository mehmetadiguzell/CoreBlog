namespace CoreBlog.Models
{
    public class AddProfilImage
    {

        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public IFormFile WriterImage { get; set; }
        public bool WriterStatus { get; set; }
    }
}
