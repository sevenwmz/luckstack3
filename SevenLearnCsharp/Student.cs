using System.Collections.Generic;

namespace SevenLearnCsharp
{
    internal class Student
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public List<Major> Majors { get; set; }
    }
}