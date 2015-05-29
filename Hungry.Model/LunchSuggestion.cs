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
    [Table("LunchSuggestion")]
    public class LunchSuggestion : AuditableEntity<long>
    {
        [Key]
        public int LunchSuggestionId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nome Local")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        public virtual ICollection<LunchVote> LunchVote { get; set; }
    }
}
