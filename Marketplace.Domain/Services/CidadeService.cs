using Marketplace.Domain.Models;
using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories;

namespace Marketplace.Domain.Services
{
    //Regra de negócio - uso de Facade (design pattern)
    public class CidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IUnidadeFederativaRepository _unidadeFederativaRepository;

        public CidadeService(
            ICidadeRepository cidadeRepository,
            IUnidadeFederativaRepository unidadeFederativaRepository)
        {
            _cidadeRepository = cidadeRepository;
            _unidadeFederativaRepository = unidadeFederativaRepository;
        }

        private async Task<EndCidade> Find(long id)
        {
            var cidade = await _cidadeRepository.GetById(id);
            if (cidade == null)
                throw new Exception("Não existe uma cidade com o código " + id);

            return cidade;
        }

        private async Task UpdateData(EndCidade cidade, EndCidade request)
        {
            var unidadeFederativa = await _unidadeFederativaRepository.GetById(request.CodigoEstado) ??
                throw new Exception($"Não existe um estado cadastro com o código {request.CodigoEstado}");

            cidade.Descricao = request.Descricao;
            cidade.CodigoEstado = unidadeFederativa.Codigo;
        }

        public async Task<EndCidade> Post(EndCidade request)
        {
            var cidade = new EndCidade();
            await UpdateData(cidade, request);

            return await _cidadeRepository.Post(cidade);
        }

        public Task<CidadeInfraQuery?> GetByIdInfraQuery(long id)
        {
            return _cidadeRepository.GetByIdInfraQuery(id);
        }

        public Task<IEnumerable<EndCidade>> Get()
        {
            return _cidadeRepository.Get();
        }

        public Task<EndCidade?> GetById(long id)
        {
            return _cidadeRepository.GetById(id);
        }

        public async Task Update(long id, EndCidade request)
        {
            var cidade = await Find(id);
            await UpdateData(cidade, request);

            await _cidadeRepository.Post(cidade);
        }
        public async Task Delete(long id)
        {
            var cidade = await Find(id);
            await _cidadeRepository.Delete(cidade);
        }
    }
}
