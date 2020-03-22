using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("ChangeDocumentsSet", Schema = "dbo")]
    public partial class ChangeDocumentsSet
    {
        [Key]
        [StringLength(15)]
        public string Changedocobjectclass { get; set; }

        [Key]
        [StringLength(90)]
        public string Changedocobject { get; set; }

        [Key]
        [StringLength(10)]
        public string Changedocument { get; set; }

        public DateTime? Creationdate { get; set; }

        [StringLength(30)]
        public string Databasetable { get; set; }

        [StringLength(1)]
        public string Changedocitemchangetype { get; set; }
    }
}
