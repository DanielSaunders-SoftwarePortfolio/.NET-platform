using System.ComponentModel.DataAnnotations;
namespace Scripture_Tracker.Models
{
    public class Scripture
    {
        public ScriptureBook Book { get; set; }
        public int Chapter { get; set; }
        public int StartVerse { get; set; }
        public int EndVerse { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public ScriptureTopic? Topic { get; set; }

        public Scripture(ScriptureBook book, int chapter, int startVerse, int endVerse, string? notes = null, ScriptureTopic topic=ScriptureTopic.Scripture)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
            Notes = notes;
            Topic  = topic;
        }
    }

    // This Enum was created with the help of chatGPT
    // because I didn't want to manually fill in all
    // of the names of every scripture book, but I
    // liked the fidelity of this structure better than
    // using a simple string.
    public enum ScriptureBook
    {
        Genesis,
        Exodus,
        Leviticus,
        Numbers,
        Deuteronomy,
        Joshua,
        Judges,
        Ruth,
        Samuel1,
        Samuel2,
        Kings1,
        Kings2,
        Chronicles1,
        Chronicles2,
        Ezra,
        Nehemiah,
        Esther,
        Job,
        Psalms,
        Proverbs,
        Ecclesiastes,
        SongOfSolomon,
        Isaiah,
        Jeremiah,
        Lamentations,
        Ezekiel,
        Daniel,
        Hosea,
        Joel,
        Amos,
        Obadiah,
        Jonah,
        Micah,
        Nahum,
        Habakkuk,
        Zephaniah,
        Haggai,
        Zechariah,
        Malachi,
        Matthew,
        Mark,
        Luke,
        John,
        Acts,
        Romans,
        Corinthians1,
        Corinthians2,
        Galatians,
        Ephesians,
        Philippians,
        Colossians,
        Thessalonians1,
        Thessalonians2,
        Timothy1,
        Timothy2,
        Titus,
        Philemon,
        Hebrews,
        James,
        Peter1,
        Peter2,
        John1,
        John2,
        John3,
        Jude,
        Revelation,
        FirstNephi,
        SecondNephi,
        Jacob,
        Enos,
        Jarom,
        Omni,
        WordsOfMormon,
        Mosiah,
        Alma,
        Helaman,
        ThirdNephi,
        FourthNephi,
        Mormon,
        Ether,
        Moroni,
        DoctrineAndCovenants,
        Moses,
        Abraham,
        ArticlesOfFaith
    }

    public enum ScriptureTopic
    {
        Scripture,
        Love,
        Faith,
        Hope,
        Prayer,
        Forgiveness,
        Compassion,
        Humility,
        Gratitude,
        Patience,
        Wisdom,
        Courage,
        Kindness,
        Repentance,
        Salvation,
        Redemption,
        Peace,
        Strength,
        Guidance,
        Grace,
        Mercy,
        Temptation,
        Trials,
        Healing,
        Unity,
        Fasting,
        Worship,
        Generosity,
        Integrity,
        Obedience,
        Atonement,
        Miracles,
        Resurrection,
        Covenant,
        Sacrifice,
        Charity,
        Repose,
        Virtue,
        Perseverance,
        Purity,
        Leadership,
        Joy,
        Endurance,
        Family,
        Promises,
        Comfort,
        Light,
        Truth,
        Trust,
        Holiness,
        Service,
        Discipleship
    }
}
