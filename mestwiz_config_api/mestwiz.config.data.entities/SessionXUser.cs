using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Session_User")]
    public class SessionXUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("session_id")]
        [MaxLength(255)]
        public string id { get; set; }
        
        [Column("session_user_id")]
        [MaxLength(255)]
        public string user_id { get; set; }

        [Column("session_data")]
        [MaxLength(8000)]
        public string data { get; set; }

        [Column("session_host")]
        [MaxLength(100)]
        public string host { get; set; }

        [Column("session_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("session_access_date")]
        public DateTime access_date { get; set; }

        [Column("session_close_date")]
        public DateTime? close_date { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }
      
    }
}