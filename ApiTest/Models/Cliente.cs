using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiTest.Models {
    [Table( "CLIENTES" )]
    public class Cliente {
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        [Key]
        public int id {get; set;}
        [Required]
        [ForeignKey("Categoria")]
        public int categoriaID { get; set; }
        [StringLength(50)]
        public string nombres { get; set; }
        [StringLength( 50 )]
        public string apellidos { get; set; }

        //public virtual Categoria Categoria { get; set; }

    }
}
