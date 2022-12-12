using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingList.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Finished { get; set; }
        public Priority Priority { get; set; }
        public int PriorityNumber { get; set; }
        public string? ImgUrl { get; set; }
    }
}
