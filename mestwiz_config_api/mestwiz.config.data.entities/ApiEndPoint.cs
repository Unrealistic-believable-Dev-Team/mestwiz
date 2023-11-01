using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mestwiz.config.data.entities
{
    [Table("TB_Api_EndPoint")]
    public class ApiEndPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("api_id")]
        [Required]
        [MaxLength(255)]
        public string id { get; set; }

        [Column("api_type")]
        [MaxLength(50)]
        public string type { get; set; }

        [Column("api_url")]
        [MaxLength(255)]
        public string url { get; set; }

        [Column("api_port")]
        public int port { get; set; }

        [Column("api_status")]
        [MaxLength(2)]
        public string status { get; set; }
    }
}