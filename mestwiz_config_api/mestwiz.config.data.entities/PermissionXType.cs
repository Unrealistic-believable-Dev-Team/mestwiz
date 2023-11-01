using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Permission_Type")]
    public class PermissionXType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("perxt_id")]
        public int id { get; set; }

        [Column("perxt_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("perxt_perm_id")]
        public int perm_id { get; set; }

        [ForeignKey("perm_id")]
        public virtual Permission Permission { get; set; }

        [Column("perxt_permt_id")]
        public int permt_id { get; set; }

        [ForeignKey("permt_id")]
        public virtual PermissionType PermissionType { get; set; }
    }
}
