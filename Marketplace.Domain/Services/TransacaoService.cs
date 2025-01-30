using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class TransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IOperacaoRepository _operacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository, IOperacaoRepository operacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
            _operacaoRepository = operacaoRepository;
        }
        private async Task<TrnTransacao> Find(long id)
        {
            var transferencia = await _transacaoRepository.GetById(id);

            if (transferencia == null)
                throw new Exception("Não existe uma transação com o código " + id);

            return transferencia;
        }
        private async Task UpdateData(TrnTransacao transacao, TrnTransacao request)
        {
            var operacao = await _operacaoRepository.GetById(request.CodigoOperacao) ??
               throw new Exception($"Não existe uma operação cadastrada com o código {request.CodigoOperacao}");

            //transacao.Codigo = request.Codigo;
            transacao.DataMovimento = request.DataMovimento;
            transacao.Quantidade = request.Quantidade;
            transacao.Saldo = request.Saldo;
            transacao.DataRegistro = request.DataRegistro;
            transacao.Usuario = request.Usuario;
            transacao.CodigoContaOrigem = request.CodigoContaOrigem;
            transacao.CodigoContaDestino = request.CodigoContaDestino;
            transacao.CodigoOperacao = request.CodigoOperacao;
        }

        public async Task<TrnTransacao?> Post(TrnTransacao request)
        {
            var transacao = new TrnTransacao();

            await UpdateData(transacao, request);

            return await _transacaoRepository.Post(transacao);
        }
        public Task<IEnumerable<TrnTransacao>> Get()
        {
            return _transacaoRepository.Get();
        }
        public Task<TrnTransacao?> GetById(long id)
        {
            return _transacaoRepository.GetById(id);
        }
        public async Task Update(long id, TrnTransacao request)
        {
            var transacao = await Find(id);

            await UpdateData(transacao, request);

            await _transacaoRepository.Update(id, transacao);
        }
        public async Task Delete(long id)
        {
            var transacao = await Find(id);
            await _transacaoRepository.Delete(transacao);    

        }
    }
}
