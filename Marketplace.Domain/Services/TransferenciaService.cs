using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class TransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ITipoTransferenciaRepository _tipoTransferenciaRepository;
        private readonly IOperacaoRepository _operacaoRepository;

        public TransferenciaService(ITransferenciaRepository trasnferenciaRepository, ITipoTransferenciaRepository tipoTransferenciaRepository, IOperacaoRepository operacaoRepository)
        {
            _transferenciaRepository = trasnferenciaRepository;
            _tipoTransferenciaRepository = tipoTransferenciaRepository;
            _operacaoRepository = operacaoRepository;
        }
        private async Task<TrnTransferencia> Find(long id)
        {
            var transferencia = await _transferenciaRepository.GetById(id);

            if (transferencia == null)
                throw new Exception("Não existe uma transferencia com o código " + id);

            return transferencia;
        }

        private async Task UpdateData(TrnTransferencia transferencia, TrnTransferencia request)
        {
            var operacao = await _operacaoRepository.GetById(request.CodigoOperacao) ??
                throw new Exception($"Não existe uma operação cadastro com o código {request.CodigoOperacao}");

            var tipoTransferencia = await _tipoTransferenciaRepository.GetById(request.CodigoTipoTransferencia) ??
                throw new Exception($"Não existe um tipo de transferência com cadastro com o código {request.CodigoTipoTransferencia}");

            transferencia.ArquivoLink = request.ArquivoLink;
            transferencia.Quantidade = request.Quantidade;
            transferencia.DataRegistro = request.DataRegistro;
            transferencia.Usuario = request.Usuario;
            transferencia.CodigoTipoTransferencia = request.CodigoTipoTransferencia;
            transferencia.CodigoContaOrigem = request.CodigoContaOrigem;
            transferencia.CodigoContaDestino = request.CodigoContaDestino;
            transferencia.CodigoOperacao = request.CodigoOperacao;
        }

        public async Task<TrnTransferencia?> Post(TrnTransferencia request)
        {
            var transferencia = new TrnTransferencia();
            await UpdateData(transferencia, request);

            return await _transferenciaRepository.Post(transferencia);
        }
        public Task<IEnumerable<TrnTransferencia>> Get()
        {
            return _transferenciaRepository.Get();
        }
        public Task<TrnTransferencia?> GetById(long id)
        {
            return _transferenciaRepository.GetById(id);
        }
        public async Task Update(long id, TrnTransferencia request)
        {
            var transferencia = await Find(id);

            await UpdateData(transferencia, request);

            await _transferenciaRepository.Update(id, transferencia);
        }
        public async Task Delete(long id)
        {
            var transferencia = await Find(id);
            await _transferenciaRepository.Delete(transferencia);
        }
    }
}
