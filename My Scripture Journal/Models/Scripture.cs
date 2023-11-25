using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace My_Scripture_Journal.Models
{
    public class Scripture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ScriptureBook Book { get; set; }
        public int Chapter { get; set; }
        public int StartVerse { get; set; }
        public int EndVerse { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public ScriptureTopic? Topic { get; set; }

        public Scripture()
        {
            Book = ScriptureBook.FirstNephi;
            Chapter = 1;
            StartVerse = 1;
            EndVerse = 1;
            CreationDate = DateTime.Today;

        }
        public string GetBookName()
        {
            var enumType = Book.GetType();
            var memberInfo = enumType.GetMember(Book.ToString());
            if (memberInfo.Length > 0)
            {
                var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    Console.WriteLine("displayAttribute.Name");
                    return displayAttribute.Name;
                }
            }
            Console.WriteLine("Book.ToString()");
            return Book.ToString();
        }
        public void Assign(Scripture NewValues)
        {
            Book = NewValues.Book;
            Chapter = NewValues.Chapter;
            StartVerse = NewValues.StartVerse;
            EndVerse= NewValues.EndVerse;
            Notes = NewValues.Notes;
            Topic = NewValues.Topic;
        }
    }
    
}
