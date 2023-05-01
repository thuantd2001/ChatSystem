using Present.Data;
using System.ComponentModel.DataAnnotations;

namespace Present.Models
{
    public class ChatModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid IndividualChatId { get; set; }
        [Required]
        public DateTime CreateAt {get;set;}

    }
}
