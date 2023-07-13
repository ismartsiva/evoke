using System.ComponentModel.DataAnnotations;

namespace CodeFirstProj0707.Models
{
    public class StudentDb
    {
        [Key]
        public int Rno { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Grade { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public int scienceMark { get; set; }
        [Required]
        public int mathmark { get; set; }

        public int total { get { return total; } set { total = scienceMark + mathmark; } }

    }
}
