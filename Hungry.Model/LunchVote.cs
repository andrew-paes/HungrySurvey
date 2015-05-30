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
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        [Display(Name = "Usuário")]
        public long DBServerUserId { get; set; }

        [ForeignKey("DBServerUserId")]
        public virtual DBServerUser DBServerUser { get; set; }

        [Display(Name = "Sugestão")]
        public long LunchSuggestionId { get; set; }

        [ForeignKey("LunchSuggestionId")]
        public virtual LunchSuggestion LunchSuggestion { get; set; }
    }
}
