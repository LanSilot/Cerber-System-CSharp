using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Models
{
    public class PresentationExModel
    {
        public String PresentationId { get; set; }
        public String UserId { get; set; }
        public String PathBeginPhoto { get; set; }
        public List<PhotoModel> Photos { get; set; } 
    }
}
