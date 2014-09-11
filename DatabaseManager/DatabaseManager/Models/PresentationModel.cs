using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseManager.Models
{
    [Table("AspNetPresentations")]
    public class PresentationModel
    {
        [Key]
        public String PresentationId { get; set; }
        public String UserId { get; set; }
        public String PathBeginPhoto { get; set; }
    }
}
