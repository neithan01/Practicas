using NetExam.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetExam.Dto
{
    public class Office : IOffice
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
    }
}
