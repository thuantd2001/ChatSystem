using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Present.Data
{
    public class IndividualChat
    {
        [Key]
        public Guid Id { get; set; }
        public string? UserSendId { get; set; }
        [ForeignKey("UserSendId")]
        public ApplicationUser? UserSend { get; set; }
        public string? UserReceiveId { get; set; }
        [ForeignKey("UserReceiveId")]
        public ApplicationUser? UserReceive { get; set; }
        public List<Chat>? Chats { get; set; }

    }
}
