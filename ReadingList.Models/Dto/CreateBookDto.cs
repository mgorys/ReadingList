using ReadingList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingList.Models.Dto
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public bool Finished { get; set; } = false;
        public Priority Priority { get; set; } = Priority.Someday;
        public string? ImgUrl { get; set; }
    }
}
