using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Permission")]
    public class Permission
    {
        public Permission() { 
            this.PermissionsXType = new HashSet<PermissionXType>();
            this.PermissionsXRole = new HashSet<PermissionXRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("perm_id")]
        public int id { get; set; }

        [Column("perm_route")]
        [MaxLength(500)]
        public string route { get; set; }

        [Column("perm_description")]
        [MaxLength(500)]
        public string description { get; set; }

        [Column("perm_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("perm_created_date")]
        public DateTime created_date { get; set; }

        [Column("perm_modified_date")]
        public DateTime? modified_date { get; set; }

        [Column("perm_created_user_id")]
        public string created_user_id { get; set; }

        [Column("perm_modified_user_id")]
        public string? modified_user_id { get; set; }

        public virtual ICollection<PermissionXType> PermissionsXType { get; set; }
        public virtual ICollection<PermissionXRole> PermissionsXRole { get; set; }
    }
}
