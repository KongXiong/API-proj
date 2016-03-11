using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Proj.Models
{
    public class RevenueCategory
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public float Total { get; set; }

        public int RevenueID { get; set; }
        public virtual Revenue Revenue { get; set; }
    }
}