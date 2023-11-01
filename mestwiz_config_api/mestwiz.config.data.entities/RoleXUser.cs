using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Role_User")]
    public class RoleXUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("rous_id")]
        public int id { get; set; }

        [Column("rous_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("rous_user_id")]
        public string user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

        [Column("rous_role_id")]
        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public virtual Role Role { get; set; }
    }
}
