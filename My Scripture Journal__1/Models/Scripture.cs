using System.ComponentModel.DataAnnotations;
namespace My_Scripture_Journal.Models
{
    public class Scripture
    {
        public int Id { get; set; }
        public ScriptureBook Book { get; set; }
        public int Chapter { get; set; }
        public int StartVerse { get; set; }
        public int EndVerse { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public ScriptureTopic? Topic { get; set; }
    }
}
