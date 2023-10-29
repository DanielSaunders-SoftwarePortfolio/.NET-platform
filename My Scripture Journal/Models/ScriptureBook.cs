using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace My_Scripture_Journal.Models
{
    public enum ScriptureBook
    {
        [Display(Name = "Genesis")]
        Genesis,

        [Display(Name = "Exodus")]
        Exodus,

        [Display(Name = "Leviticus")]
        Leviticus,

        [Display(Name = "Numbers")]
        Numbers,

        [Display(Name = "Deuteronomy")]
        Deuteronomy,

        [Display(Name = "Joshua")]
        Joshua,

        [Display(Name = "Judges")]
        Judges,

        [Display(Name = "Ruth")]
        Ruth,

        [Display(Name = "1 Samuel")]
        FirstSamuel,

        [Display(Name = "2 Samuel")]
        SecondSamuel,

        [Display(Name = "1 Kings")]
        FirstKings,

        [Display(Name = "2 Kings")]
        SecondKings,

        [Display(Name = "1 Chronicles")]
        FirstChronicles,

        [Display(Name = "2 Chronicles")]
        SecondChronicles,

        [Display(Name = "Ezra")]
        Ezra,

        [Display(Name = "Nehemiah")]
        Nehemiah,

        [Display(Name = "Esther")]
        Esther,

        [Display(Name = "Job")]
        Job,

        [Display(Name = "Psalms")]
        Psalms,

        [Display(Name = "Proverbs")]
        Proverbs,

        [Display(Name = "Ecclesiastes")]
        Ecclesiastes,

        [Display(Name = "Song of Solomon")]
        SongOfSolomon,

        [Display(Name = "Isaiah")]
        Isaiah,

        [Display(Name = "Jeremiah")]
        Jeremiah,

        [Display(Name = "Lamentations")]
        Lamentations,

        [Display(Name = "Ezekiel")]
        Ezekiel,

        [Display(Name = "Daniel")]
        Daniel,

        [Display(Name = "Hosea")]
        Hosea,

        [Display(Name = "Joel")]
        Joel,

        [Display(Name = "Amos")]
        Amos,

        [Display(Name = "Obadiah")]
        Obadiah,

        [Display(Name = "Jonah")]
        Jonah,

        [Display(Name = "Micah")]
        Micah,

        [Display(Name = "Nahum")]
        Nahum,

        [Display(Name = "Habakkuk")]
        Habakkuk,

        [Display(Name = "Zephaniah")]
        Zephaniah,

        [Display(Name = "Haggai")]
        Haggai,

        [Display(Name = "Zechariah")]
        Zechariah,

        [Display(Name = "Malachi")]
        Malachi,

        // Book of Mormon
        [Display(Name = "1 Nephi")]
        FirstNephi,

        [Display(Name = "2 Nephi")]
        SecondNephi,

        [Display(Name = "Jacob")]
        Jacob,

        [Display(Name = "Enos")]
        Enos,

        [Display(Name = "Jarom")]
        Jarom,

        [Display(Name = "Omni")]
        Omni,

        [Display(Name = "Words of Mormon")]
        WordsOfMormon,

        [Display(Name = "Mosiah")]
        Mosiah,

        [Display(Name = "Alma")]
        Alma,

        [Display(Name = "Helaman")]
        Helaman,

        [Display(Name = "3 Nephi")]
        ThirdNephi,

        [Display(Name = "4 Nephi")]
        FourthNephi,

        [Display(Name = "Mormon")]
        Mormon,

        [Display(Name = "Ether")]
        Ether,

        [Display(Name = "Moroni")]
        Moroni,

        // Doctrine and Covenants (D&C)
        [Display(Name = "D&C")]
        DandC,

        // Pearl of Great Price (PoGP)
        [Display(Name = "Moses")]
        Moses,

        [Display(Name = "Abraham")]
        Abraham,

        [Display(Name = "Joseph Smith—Matthew")]
        JosephSmithMatthew,

        [Display(Name = "Joseph Smith—History")]
        JosephSmithHistory,

        [Display(Name = "Articles of Faith")]
        ArticlesOfFaith
    }
   
}
