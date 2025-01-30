using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class ContatoEnderecoService
    {
        private readonly IContatoEnderecoRepository _contatoEnderecoRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IOperacaoRepository _operacaoRepository;

        public ContatoEnderecoService(IContatoEnderecoRepository contatoEnderecoRepository, IContatoRepository contatoRepository,
            IEnderecoRepository enderecoRepository, IOperacaoRepository operacaoRepository)
        {
            _contatoEnderecoRepository = contatoEnderecoRepository;
            _contatoRepository = contatoRepository;
            _enderecoRepository = enderecoRepository;
            _operacaoRepository = operacaoRepository;
        }
        private async Task<CntEndContatoEndereco> Find(long id)
        {
            var contatoEndereco = await _contatoEnderecoRepository.GetById(id);

            if (contatoEndereco == null)
                throw new Exception("Não existe um contato-endereço com o código " + id);

            return contatoEndereco;
        }
        private async Task UpdateData(CntEndContatoEndereco contatoEndereco, CntEndContatoEndereco request)
        {
            var contato = await _contatoEnderecoRepository.GetById(request.Codigo) ??
                throw new Exception($"Não existe um contato cadastrado com o código {request.Codigo}");

            var endereco = await _enderecoRepository.GetById(request.CodigoEndereco) ??
               throw new Exception($"Não existe um endereço cadastrado com o código {request.CodigoEndereco}");

            var operacao = await _operacaoRepository.GetById(request.CodigoOperacao) ??
               throw new Exception($"Não existe uma operação cadastrada com o código {request.CodigoOperacao}");

            contatoEndereco.Usuario = request.Usuario;
            contatoEndereco.DataRegistro = request.DataRegistro;
            contatoEndereco.CodigoContato = contato.Codigo;
            contatoEndereco.CodigoEndereco = endereco.Codigo;
            contatoEndereco.CodigoOperacao = operacao.Codigo;
        }

        public async Task<CntEndContatoEndereco?> Post(CntEndContatoEndereco request)
        {
            var contatoEndereco = new CntEndContatoEndereco();

            //contatoEndereco.Codigo = request.Codigo;
            //contatoEndereco.DataRegistro = request.DataRegistro;
            //contatoEndereco.Usuario = request.Usuario;
            //contatoEndereco.CodigoContato = request.CodigoContato;
            //contatoEndereco.CodigoEndereco = request.CodigoEndereco;
            //contatoEndereco.CodigoOperacao = request.CodigoOperacao;

            await UpdateData(contatoEndereco, request);

            return await _contatoEnderecoRepository.Post(contatoEndereco);
        }

        public Task<IEnumerable<CntEndContatoEndereco>> Get()
        {
            return _contatoEnderecoRepository.Get();
        }
        public Task<CntEndContatoEndereco?> GetById(long id)
        {
            return _contatoEnderecoRepository.GetById(id);
        }
        public async Task Update(long id, CntEndContatoEndereco request)
        {
            var contatoEndereco = await Find(id);

            //contatoEndereco.Codigo = request.Codigo;
            //contatoEndereco.DataRegistro = request.DataRegistro;
            //contatoEndereco.Usuario = request.Usuario;
            //contatoEndereco.CodigoContato = request.CodigoContato;
            //contatoEndereco.CodigoEndereco = request.CodigoEndereco;
            //contatoEndereco.CodigoOperacao = request.CodigoOperacao;

            await UpdateData(contatoEndereco, request);

            await _contatoEnderecoRepository.Update(id, contatoEndereco);
        }
        public async Task Delete(long id)
        {
            var contatoEndereco = await Find(id);
            await _contatoEnderecoRepository.Delete(contatoEndereco);    

        }
    }
}
