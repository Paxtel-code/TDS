using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Api.Model;

using Microsoft.EntityFrameworkCore;

namespace ProdutosEFCore.Data
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options) {

        }

        public DbSet<ProdutosModel> Produtos { get; set; }
    }
}