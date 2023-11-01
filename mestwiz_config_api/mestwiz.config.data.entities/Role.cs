using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Cat_Role")]
    public class Role
    {
        public Role()
        {
            this.Permissions = new HashSet<Permission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public int id { get; set; }

        [Column("role_name")]
        [MaxLength(50)]
        public string name { get; set; }

        [Column("role_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("role_created_date")]
        public DateTime created_date { get; set; }

        [Column("role_modified_date")]
        public DateTime? modified_date { get; set; }

        [Column("role_created_user_id")]
        public string created_user_id { get; set; }

        [Column("role_modified_user_id")]
        public string?  modified_user_id { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
