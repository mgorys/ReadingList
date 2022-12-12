using ReadingList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingList.Models.Dto
{
    public class BookDto
    {
        public string Name { get; set; }
        public bool Finished { get; set; }
        public int PriorityNumber { get; set; }
        public string? ImgUrl { get; set; }
    }
}
