using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class TipoTransferenciaService
    {
        private readonly ITipoTransferenciaRepository _tipoTransferenciaRepository;

        public TipoTransferenciaService(ITipoTransferenciaRepository tipoTransferenciaRepository)
        {
            _tipoTransferenciaRepository = tipoTransferenciaRepository;
        }
        private async Task<TrnTipoTransferencia> Find(long id)
        {
            var tipoTransferencia = await _tipoTransferenciaRepository.GetById(id);

            if (tipoTransferencia == null)
                throw new Exception("Não existe um tipo de transferencia com o código " + id);

            return tipoTransferencia;
        }

        public Task<TrnTipoTransferencia?> Post(TrnTipoTransferencia request)
        {
            var tipoTransferencia = new TrnTipoTransferencia();
            //tipoTransferencia.Codigo = request.Codigo;
            tipoTransferencia.Descricao = request.Descricao;

            return _tipoTransferenciaRepository.Post(tipoTransferencia);
        }
        public Task<IEnumerable<TrnTipoTransferencia>> Get()
        {
            return _tipoTransferenciaRepository.Get();
        }
        public Task<TrnTipoTransferencia?> GetById(long id)
        {
            return _tipoTransferenciaRepository.GetById(id);
        }
        public async Task Update(long id, TrnTipoTransferencia request)
        {
            var tipoTransferencia = await Find(id);

            //tipoTransferencia.Codigo = request.Codigo;
            tipoTransferencia.Descricao = request.Descricao;

            await _tipoTransferenciaRepository.Update(id, tipoTransferencia);
        }
        public async Task Delete(long id)
        {
            var tipoTransferencia = await Find(id);
            await _tipoTransferenciaRepository.Delete(tipoTransferencia);    

        }
    }
}
