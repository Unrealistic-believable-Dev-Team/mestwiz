using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Email_User")]
    public class EmailXUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("email_id")]
        [MaxLength(255)]
        public string id { get; set; }

        [Column("email_user_id")]
        [MaxLength(255)]
        public string user_id { get; set; }

        [Column("email_default")]
        public bool _default { get; set; }

        [Column("email_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("email_created_date")]
        public DateTime created_date { get; set; }

        [Column("email_updated_date")]
        public DateTime? updated_date { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }
    }
}
