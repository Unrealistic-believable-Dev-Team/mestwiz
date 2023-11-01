using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Permission_Role")]
    public class PermissionXRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pero_id")]
        public int id { get; set; }

        [Column("pero_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("pero_perm_id")]
        public int perm_id { get; set; }

        [ForeignKey("perm_id")]
        public virtual Permission Permission { get; set; }

        [Column("pero_role_id")]
        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public virtual Role Role { get; set; }
    }
}
