using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.DAL.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Heading { get; set; }
        public string Text { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
