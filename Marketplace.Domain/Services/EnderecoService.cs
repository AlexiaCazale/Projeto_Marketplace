using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class EnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly ICidadeRepository _cidadeRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, IOperacaoRepository operacaoRepository, IContatoRepository contatoRepository, ICidadeRepository cidadeRepository)
        {
            _enderecoRepository = enderecoRepository;
            _operacaoRepository = operacaoRepository;
            _contatoRepository = contatoRepository;
            _cidadeRepository = cidadeRepository;
        }
        private async Task<EndEndereco> Find(long id)
        {
            var endereco = await _enderecoRepository.GetById(id);

            if (endereco == null)
                throw new Exception("Não existe um endereço com o código " + id);

            return endereco;
        }

        private async Task UpdateData(EndEndereco endereco, EndEndereco request)
        {
            var contato = await _contatoRepository.GetById(request.CodigoContato) ??
                throw new Exception($"Não existe um contato cadastrado com o código {request.CodigoContato}");

            var cidade = await _cidadeRepository.GetById(request.CodigoCidade) ??
                throw new Exception($"Não existe uma cidade cadastrada com o código {request.CodigoCidade}");

            var operacao = await _operacaoRepository.GetById(request.CodigoOperacao) ??
               throw new Exception($"Não existe uma operação cadastrada com o código {request.CodigoOperacao}");

            endereco.Bairro = request.Bairro;
            endereco.Logradouro = request.Logradouro;
            endereco.CEP = request.CEP;
            endereco.Numero = request.Numero;
            endereco.Referencia = request.Referencia;
            endereco.DataRegistro = request.DataRegistro;
            endereco.Usuario = request.Usuario;
            endereco.CodigoContato = request.CodigoContato;
            endereco.CodigoCidade = request.CodigoCidade;
            endereco.CodigoOperacao = request.CodigoOperacao;
        }
        public async Task<EndEndereco?> Post(EndEndereco request)
        {
            var endereco = new EndEndereco();

            await UpdateData(endereco, request);

            return await _enderecoRepository.Post(endereco);
        }
        public Task<IEnumerable<EndEndereco>> Get()
        {
            return _enderecoRepository.Get();
        }
        public Task<EndEndereco?> GetById(long id)
        {
            return _enderecoRepository.GetById(id);
        }
        public async Task Update(long id, EndEndereco request)
        {
            var endereco = await Find(id);

            await UpdateData(endereco, request);

            await _enderecoRepository.Update(id, endereco);
        }
        public async Task Delete(long id)
        {
            var endereco = await Find(id);
            await _enderecoRepository.Delete(endereco);    

        }
    }
}
