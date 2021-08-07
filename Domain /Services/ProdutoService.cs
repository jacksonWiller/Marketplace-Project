using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Domain.Service
{
    public class ProdutoService
    {
        private readonly IProduto _IProduct;
        private readonly IGeneric<Produto> _IGeneric;

        public ProdutoService(IProduto IProduct, IGeneric<Produto> IGeneric)
        {
            _IProduct = IProduct;
            _IGeneric = IGeneric;
        }

        public async Task AddProduct(Produto produto)
        {
            var validaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");

            if (validaNome && validaValor)
            {
                //produto.Estado = true;
                await _IGeneric.Add(produto);
            }
        }

        public async Task UpdateProduct(Produto produto)
        {
            var validaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");

            if (validaNome && validaValor)
            {
                await _IGeneric.Update(produto);
            }
        }
    }
}