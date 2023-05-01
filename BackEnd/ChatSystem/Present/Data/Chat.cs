using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Present.Data
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Text")]
        public string? Message { get; set; }
        public Guid? IndividualChatId { get; set; }
        [ForeignKey("IndividualChatId")]
        public IndividualChat? IndividualChat { get; set; }

        public DateTime? CreateAt { get; set; }
    }
}
