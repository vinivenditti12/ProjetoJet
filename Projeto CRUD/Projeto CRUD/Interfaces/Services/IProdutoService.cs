using Projeto_CRUD.Model;

namespace Projeto_CRUD.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetProdutos();
        Task<Produto> GetById(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto);
        Task<bool> DeleteProduto(int id);
    }
}
