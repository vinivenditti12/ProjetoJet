using Projeto_CRUD.Model;

namespace Projeto_CRUD.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetProdutos();
        Task<Produto> GetById(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto);
        Task<bool> DeleteProduto(Produto produto);










    }
}
