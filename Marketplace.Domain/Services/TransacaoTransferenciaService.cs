using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class TransacaoTransferenciaService
    {
        private readonly ITransacaoTransferenciaRepository _transacaoTransferenciaRepository;
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly ITransferenciaRepository _transferenciaRepository;

        public TransacaoTransferenciaService(ITransacaoTransferenciaRepository transacaoTransferenciaRepository, IOperacaoRepository operacaoRepository, ITransacaoRepository transacaoRepository, ITransferenciaRepository transferenciaRepository)
        {
            _transacaoTransferenciaRepository = transacaoTransferenciaRepository;
            _operacaoRepository = operacaoRepository;
            _transacaoRepository = transacaoRepository;
            _transferenciaRepository = transferenciaRepository;
        }
        private async Task<TrnTransacaoTransferencia> Find(long id)
        {
            var transacaoTransferencia = await _transacaoTransferenciaRepository.GetById(id);

            if (transacaoTransferencia == null)
                throw new Exception("Não existe uma transação-transferência com o código " + id);

            return transacaoTransferencia;
        }

        private async Task UpdateData(TrnTransacaoTransferencia transacaoTransferencia, TrnTransacaoTransferencia request)
        {
            var operacao = await _operacaoRepository.GetById(request.CodigoOperacao) ??
                throw new Exception($"Não existe uma operação cadastro com o código {request.CodigoOperacao}");

            var transferencia = await _transferenciaRepository.GetById(request.CodigoTransferencia) ??
                throw new Exception($"Não existe uma transferêcnia cadastro com o código {request.CodigoTransferencia}");

            var transacao = await _transacaoRepository.GetById(request.CodigoTransacao) ??
                throw new Exception($"Não existe uma transação cadastro com o código {request.CodigoTransacao}");

            transacaoTransferencia.DataRegistro = request.DataRegistro;
            transacaoTransferencia.Usuario = request.Usuario;
            transacaoTransferencia.CodigoTransacao = request.CodigoTransacao;
            transacaoTransferencia.CodigoTransferencia = request.CodigoTransferencia;
            transacaoTransferencia.CodigoOperacao = request.CodigoOperacao;
        }
        public async Task<TrnTransacaoTransferencia?> Post(TrnTransacaoTransferencia request)
        {
            var transacaoTransferencia = new TrnTransacaoTransferencia();
            await UpdateData(transacaoTransferencia, request);


            return await _transacaoTransferenciaRepository.Post(transacaoTransferencia);
        }
        public Task<IEnumerable<TrnTransacaoTransferencia>> Get()
        {
            return _transacaoTransferenciaRepository.Get();
        }
        public Task<TrnTransacaoTransferencia?> GetById(long id)
        {
            return _transacaoTransferenciaRepository.GetById(id);
        }
        public async Task Update(long id, TrnTransacaoTransferencia request)
        {
            var transacaoTransferencia = await Find(id);

            await UpdateData(transacaoTransferencia, request);

            await _transacaoTransferenciaRepository.Update(id, transacaoTransferencia);
        }
        public async Task Delete(long id)
        {
            var transacaoTransferencia = await Find(id);
            await _transacaoTransferenciaRepository.Delete(transacaoTransferencia);    

        }
    }
}
