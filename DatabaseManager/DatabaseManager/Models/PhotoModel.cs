using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseManager.Models
{
    [Table("AspNetPhotos")]
    public class PhotoModel
    {
        [Key]
        public String PhotoId { get; set; }
        public String UserId { get; set; }
        public String PhotoPath { get; set; }
        public String PhotoName { get; set; }
        public String PhotoDescription { get; set; }
        public String PresentationId { get; set; }
        public Int32 PositionNumber { get; set; }
    }
}
