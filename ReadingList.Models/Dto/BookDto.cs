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
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public bool Finished { get; set; }
        public Priority Priority { get; set; }
        public string? ImgUrl { get; set; }
    }
}
