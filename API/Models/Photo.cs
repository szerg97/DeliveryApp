using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace API.Models
{
    [Table("Photo")]
    public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }

        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        [ForeignKey("Site")]
        [NotNull]
        public string SiteId { get; set; }
        public virtual Site Site { get; set; }
    }
}