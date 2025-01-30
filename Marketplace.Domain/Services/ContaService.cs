using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Marketplace.Domain.Services
{
    public class ContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly IOperacaoRepository _operacaoRepository;
        public ContaService(IContaRepository contaRepository, IOperacaoRepository operacaoRepository, IContatoRepository contatoRepository)
        {
            _contaRepository = contaRepository;
            _contatoRepository = contatoRepository;
            _operacaoRepository = operacaoRepository;
        }
        private async Task<CtaConta> Find(long id)
        {
            var conta = await _contaRepository.GetById(id);

            if (conta == null)
                throw new Exception("Não existe uma conta com o código " + id);

            return conta;
        }

        private async Task UpdateData(CtaConta conta, CtaConta request)
        {
            var contato = await _contatoRepository.GetById(request.CodigoContato) ??
                throw new Exception($"Não existe um contato cadastrado com o código {request.CodigoContato}");

            var operacao = await _operacaoRepository.GetById(request.CodigoOperacao) ??
               throw new Exception($"Não existe uma operação cadastrada com o código {request.CodigoOperacao}");

            conta.Usuario = request.Usuario;
            conta.DataRegisto = request.DataRegisto;
            conta.Saldo = request.Saldo;
            conta.Descricao = request.Descricao;
            conta.CodigoSuperior = request.CodigoSuperior;
            conta.CodigoContato = contato.Codigo;
            conta.CodigoOperacao = operacao.Codigo;
        }

        public async Task<CtaConta?> Post(CtaConta request)
        {
            var conta = new CtaConta();

            await UpdateData(conta, request);

            return await _contaRepository.Post(conta);
        }
        public Task<IEnumerable<CtaConta>> Get()
        {
            return _contaRepository.Get();
        }
        public Task<CtaConta?> GetById(long id)
        {
            return _contaRepository.GetById(id);
        }
        public async Task Update(long id, CtaConta request)
        {
            var conta = await Find(id);

            await UpdateData(conta, request);

            await _contaRepository.Update(id, conta);
        }
        public async Task Delete(long id)
        {
            var conta = await Find(id);
            await _contaRepository.Delete(conta);    

        }
    }
}
