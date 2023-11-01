using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Cat_Permission_Type")]
    public class PermissionType
    {
        public PermissionType()
        {
            this.PermissionXTypes = new HashSet<PermissionXType>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("permt_id")]
        public int id { get; set; }

        [Column("permt_method")]
        [MaxLength(50)]
        public string method { get; set; }

        [Column("permt_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("permt_created_date")]
        public DateTime? created_date { get; set; }

        [Column("permt_modified_date")]
        public DateTime? modified_date { get; set; }

        [Column("permt_created_user_id")]
        public string created_user_id { get; set; }

        [Column("permt_modified_user_id")]
        public string? modified_user_id { get; set; }

        public virtual ICollection<PermissionXType> PermissionXTypes { get; set; }
    }
}
