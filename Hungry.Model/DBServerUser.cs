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
    [Table("DBServerUser")]
    public class DBServerUser : AuditableEntity<long>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        public virtual ICollection<LunchVote> LunchVote { get; set; }
    }
}
