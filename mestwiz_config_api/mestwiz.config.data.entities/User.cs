using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mestwiz.config.data.entities
{
    [Table("TB_User")]
    public class User
    {

        public User()
        {
            this.PhonesXUser = new HashSet<PhoneXUser>();
            this.EmailsXUser = new HashSet<EmailXUser>();
            this.SessionsXUser = new HashSet<SessionXUser>();
            this.TokensXUser = new HashSet<TokenXUser>();
            this.RolesXUser = new HashSet<RoleXUser>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("user_id")]
        [MaxLength(255)]
        public string id { get; set; }

        [Column("user_name")]
        [MaxLength(100)]
        public string name { get; set; }

        [Column("user_full_name")]
        [MaxLength(500)]
        public string full_name { get; set; }

        [Column("user_password")]
        [MaxLength(100)]
        public string password { get; set; }

        [Column("user_cipher_type")]
        [MaxLength(50)]
        public string cipher_type { get; set; }

        [Column("user_cipher_secret")]
        [MaxLength(50)]
        public string cipher_secret { get; set; }

        [Column("user_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("user_created_date")]
        public DateTime? created_date { get; set; }

        [Column("user_updated_date")]
        public DateTime? updated_date { get; set; }

        public virtual ICollection<PhoneXUser> PhonesXUser { get; set; }
        public virtual ICollection<EmailXUser> EmailsXUser { get; set; }
        public virtual ICollection<SessionXUser> SessionsXUser { get; set; }
        public virtual ICollection<TokenXUser> TokensXUser { get; set; }
        public virtual ICollection<RoleXUser> RolesXUser { get; set; }

    }
}
