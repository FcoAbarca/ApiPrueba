using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiTest.Models {
    [Table( "Categoria" )]
    public class Categoria {
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        [Key]
        public int id { get; set; }
        [StringLength( 30 )]
        public string categoria { get; set; }

        //public List<IEnumerable<Cliente>> Clientes { get; set; }
    }
}
