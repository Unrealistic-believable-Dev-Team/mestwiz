using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities
{
    [Table("TB_Phone_User")]
    public class PhoneXUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("phone_id")]
        [MaxLength(20)]
        public string id { get; set; }
        
        [Column("phone_user_id")]
        [MaxLength(255)]
        public string user_id { get; set; }

        [Column("phone_default")]
        public bool _default { get; set; }

        [Column("phone_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("phone_created_date")]
        public DateTime created_date { get; set; }

        [Column("phone_updated_date")]
        public DateTime? updated_date { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }
    }
}