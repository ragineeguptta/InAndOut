using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Stream name")]
        public string Stream { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
