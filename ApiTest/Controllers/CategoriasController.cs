using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiTest.Models;
namespace ApiTest.Controllers {
    [Route( "api/[controller]" )]
    [ApiController]
    public class CategoriasController : ControllerBase {
        public _dbContext _context { get; }
        public CategoriasController(_dbContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Categoria> GetAll() {
            return (from a in _context.Categorias
                    select a).ToArray();
        }
    }

}
