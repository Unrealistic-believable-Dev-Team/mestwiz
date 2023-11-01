using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Token_User")]
    public class TokenXUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("token_id")]
        [MaxLength(255)]
        public string id { get; set; }

        [Column("token_created_date")]
        public DateTime? created_date { get; set; }

        [Column("token_expiry_date")]
        public DateTime? expiry_date { get; set; }

        [Column("token_status")]
        [MaxLength(2)]
        public string status { get; set; }
       
        [Column("token_user_id")]
        [MaxLength(255)]
        public string user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }
    }
}