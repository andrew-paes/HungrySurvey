using Hungry.Model.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Model
{
    [Table("LunchVotes")]
    public class LunchVote : AuditableEntity<long>
    {
        public int Id { get; set; }

        [Display(Name = "Usuário")]
        public int UserId { get; set; }

        [Display(Name = "Sugestão")]
        public int LunchSuggestionId { get; set; }

        [ForeignKey("UserId")]
        public virtual DBServerUser DBServerUser { get; set; }

        [ForeignKey("LunchSuggestionId")]
        public virtual LunchSuggestion LunchSuggestion { get; set; }
    }
}
