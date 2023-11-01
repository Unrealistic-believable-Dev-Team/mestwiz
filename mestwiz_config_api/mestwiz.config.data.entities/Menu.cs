
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mestwiz.config.data.entities
{
    [Table("TB_Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("menu_id")]
        public int id { get; set; }

        [Column("menu_parent_id")]
        public int parent_id { get; set; }

        [Column("menu_description")]
        [MaxLength(500)]
        public string description { get; set; }

        [Column("menu_route")]
        [MaxLength(500)]
        public string route { get; set; }

        [Column("menu_status")]
        [MaxLength(2)]
        public string status { get; set; }

        [Column("menu_created_date")]
        public DateTime created_date { get; set; }

        [Column("menu_modified_date")]
        public DateTime? modified_date { get; set; }

        [Column("menu_created_user_id")]
        public string created_user_id { get; set; }

        [Column("menu_modified_user_id")]
        public string? modified_user_id { get; set; }
    }
}
