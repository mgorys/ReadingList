using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class ServerResponse<T>
    {
        public T? DataFromServer { get; set; }
        public bool Success { get; set; } = false;
    }
}
