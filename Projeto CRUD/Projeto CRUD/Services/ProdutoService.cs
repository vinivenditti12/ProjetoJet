using Projeto_CRUD.Interfaces.Repositories;
using Projeto_CRUD.Interfaces.Services;
using Projeto_CRUD.Model;

namespace Projeto_CRUD.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> AddProduto(Produto produto)
        {
            await _repository.AddProduto(produto);

            return produto;
        }

        public async Task<bool> DeleteProduto(int id)
        {
            Produto produto = await GetById(id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }
            await _repository.DeleteProduto(produto);

            return true;
        }

        public async Task<Produto> GetById(int id)
        {
            Produto produto = await _repository.GetById(id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }
            return produto;
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _repository.GetProdutos();
        }

        public async Task<Produto> UpdateProduto(Produto produto)
        {
            Produto produtoToUpdate = await GetById(produto.IdProduto);

            if (produtoToUpdate == null)
            {
                throw new Exception("Produto não encontrado");
            }
            produtoToUpdate.Nome = produto.Nome;
            produtoToUpdate.Imagem = produto.Imagem;
            produtoToUpdate.Preco = produto.Preco;
            produtoToUpdate.Descricao = produto.Descricao;
            produtoToUpdate.Status = produto.Status;
            produtoToUpdate.Estoque = produto.Estoque;

            await _repository.UpdateProduto(produtoToUpdate);

            return produtoToUpdate;
        }
    }
}
