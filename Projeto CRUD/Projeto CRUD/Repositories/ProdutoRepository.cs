using Projeto_CRUD.Data;
using Projeto_CRUD.Interfaces.Repositories;
using Projeto_CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace Projeto_CRUD.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;
        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Produto> AddProduto(Produto produto)
        {
            await _context.Produtos.AddAsync(produto); 
            await _context.SaveChangesAsync();

            return produto;
        }


        public async Task<bool> DeleteProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == id);
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();

        }

        public async Task<Produto> UpdateProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();

            return produto;
        }
    }
}
