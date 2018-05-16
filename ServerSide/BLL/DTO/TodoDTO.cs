using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.BLL.DTO
{
    public class TodoDto
    {
        public ulong Id { get; set; }

        public string Heading { get; set; }
        public string Text { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
