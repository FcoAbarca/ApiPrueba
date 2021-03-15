using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers {
    [Route( "api/[controller]" )]
    [ApiController]
    public class ClientesController : ControllerBase {
        public _dbContext _context { get; }
        public ClientesController(_dbContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAll() {
            return _context.Clientes.Include(x=> x.Categoria).ToList();
            
            /*return (from a in _context.Clientes
                    join b in _context.Categorias on a.categoriaID equals b.id
                    select new ViewCliente {
                        id = a.id,
                        categoria = b.categoria,
                        nombreCompleto = a.nombres + " " + a.apellidos,
                    }).ToArray();*/
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id) {
            var cliente = _context.Clientes.Find( id );

            if (cliente == null)
                return NotFound();
            else
                return Ok( cliente );
        }
        [HttpGet("categoria/{categoria}")]
        public IActionResult GetCategoria( int categoria) {
            var clientes = (from a in _context.Clientes
                    join b in _context.Categorias on a.categoriaID equals b.id
                    where b.id == categoria
                    select new ViewCliente {
                        id = a.id,
                        categoria = b.categoria,
                        nombreCompleto = a.nombres + " " + a.apellidos,
                    }).ToArray();

            if (clientes == null)
                return NotFound();
            else
                return Ok( clientes );
        }
        [HttpGet( "nombre/{nombre}" )]
        public IActionResult GetNombre(string nombre) {
            var clientes = (from a in _context.Clientes
                    join b in _context.Categorias on a.categoriaID equals b.id
                    select new ViewCliente {
                        id = a.id,
                        categoria = b.categoria,
                        nombreCompleto = a.nombres + " " + a.apellidos,
                    }).ToArray().Where( a => a.nombreCompleto.ToUpper().Contains( nombre.ToUpper() ) );

            if (clientes == null)
                return NotFound();
            else
                return Ok( clientes );
        }
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente) {
            if (ModelState.IsValid) {
                _context.Clientes.Add( cliente );
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest( ModelState );
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Cliente cliente, int id) {
            if (cliente.id != id) {
                return BadRequest();
            }

            _context.Entry( cliente ).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete( int id) {
            var cliente = _context.Clientes.Find( id );

            if (cliente == null) {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return Ok();
        }
    }

    public class ViewCliente {
        public int id { get; set; }
        public string categoria { get; set; }
        public string nombreCompleto { get; set; }
    }
}
