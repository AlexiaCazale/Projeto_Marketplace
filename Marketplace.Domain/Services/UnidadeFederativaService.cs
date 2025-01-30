using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class UnidadeFederativaService
    {
        private readonly IUnidadeFederativaRepository _unidadeFederativaRepository;

        public UnidadeFederativaService(IUnidadeFederativaRepository unidadeFederativaRepository)
        {
            _unidadeFederativaRepository = unidadeFederativaRepository;
        }
        private async Task<EndUnidadeFederativa> Find(long id)
        {
            var unidadeFederativa = await _unidadeFederativaRepository.GetById(id);

            if (unidadeFederativa == null)
                throw new Exception("Não existe uma unidade federativa com o código " + id);

            return unidadeFederativa;
        }

        public Task<EndUnidadeFederativa?> Post(EndUnidadeFederativa request)
        {
            var unidadeFederativa = new EndUnidadeFederativa();
            unidadeFederativa.Descricao = request.Descricao;
            unidadeFederativa.Sigla = request.Sigla;

            return _unidadeFederativaRepository.Post(unidadeFederativa);
        }
        public Task<IEnumerable<EndUnidadeFederativa>> Get()
        {
            return _unidadeFederativaRepository.Get();
        }
        public Task<EndUnidadeFederativa?> GetById(long id)
        {
            return _unidadeFederativaRepository.GetById(id);
        }
        public async Task Update(long id, EndUnidadeFederativa request)
        {
            var unidadeFederativa = await Find(id);

            unidadeFederativa.Descricao = request.Descricao;
            unidadeFederativa.Sigla = request.Sigla;

            await _unidadeFederativaRepository.Update(id, unidadeFederativa);
        }
        public async Task Delete(long id)
        {
            var unidadeFederativa = await Find(id);
            await _unidadeFederativaRepository.Delete(unidadeFederativa);    

        }
    }
}
