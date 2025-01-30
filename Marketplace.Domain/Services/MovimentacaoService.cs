using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class MovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IOperacaoRepository _operacaoRepository;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository, ITransacaoRepository ransacaoRepository, IContaRepository contaRepository, IOperacaoRepository operacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _transacaoRepository = ransacaoRepository;
            _contaRepository = contaRepository;
            _operacaoRepository = operacaoRepository;
        }
        private async Task<CtaMovimentacao> Find(long id)
        {
            var movimentacao = await _movimentacaoRepository.GetById(id);

            if (movimentacao == null)
                throw new Exception("Não existe uma movimentação com o código " + id);

            return movimentacao;
        }

        private async Task UpdateData(CtaMovimentacao movimentacao, CtaMovimentacao request)
        {
            var operacao = await _operacaoRepository.GetById(request.CodigoOperacao) ??
               throw new Exception($"Não existe uma operação cadastrada com o código {request.CodigoOperacao}");

            var transacao = await _transacaoRepository.GetById(request.CodigoTransacao) ??
               throw new Exception($"Não existe uma transação cadastrada com o código {request.CodigoTransacao}");

            var conta = await _contaRepository.GetById(request.CodigoConta) ??
               throw new Exception($"Não existe uma conta cadastrada com o código {request.CodigoConta}");

            movimentacao.DataMovimento = request.DataMovimento;
            movimentacao.Quantidade = request.Quantidade;
            movimentacao.DataRegistro = request.DataRegistro;
            movimentacao.Usuario = request.Usuario;
            movimentacao.CodigoTransacao = request.CodigoTransacao;
            movimentacao.CodigoConta = request.CodigoConta;
            movimentacao.CodigoOperacao = request.CodigoOperacao;
        }

        public async Task<CtaMovimentacao?> Post(CtaMovimentacao request)
        {
            var movimentacao = new CtaMovimentacao();
            await UpdateData(movimentacao, request);

            return await _movimentacaoRepository.Post(movimentacao);
        }
        public Task<IEnumerable<CtaMovimentacao>> Get()
        {
            return _movimentacaoRepository.Get();
        }
        public Task<CtaMovimentacao?> GetById(long id)
        {
            return _movimentacaoRepository.GetById(id);
        }
        public async Task Update(long id, CtaMovimentacao request)
        {
            var movimentacao = await Find(id);

            await UpdateData(movimentacao, request);

            await _movimentacaoRepository.Update(id, movimentacao);
        }
        public async Task Delete(long id)
        {
            var movimentacao = await Find(id);
            await _movimentacaoRepository.Delete(movimentacao);    

        }
    }
}
