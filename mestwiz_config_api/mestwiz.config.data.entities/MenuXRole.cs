

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mestwiz.config.data.entities
{
    [Table("TB_Menu_Role")]
    public class MenuXRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("mero_id")]
        public int id { get; set; }

        [Column("mero_role_id")]
        public int role_id { get; set; }

        [Column("mero_menu_id")]
        public int menu_id { get; set; }

        [Column("mero_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("mero_created_date")]
        public DateTime created_date { get; set; }

        [Column("mero_modified_date")]
        public DateTime? modified_date { get; set; }

        [Column("mero_created_user_id")]
        public string created_user_id { get; set; }

        [Column("mero_modified_user_id")]
        public string? modified_user_id { get; set; }

        [ForeignKey("role_id")]
        public virtual Role Role { get; set; }

        [ForeignKey("menu_id")]
        public virtual Menu Menu { get; set; }
    }
}
