using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories;
using Marketplace.Domain.Models;
using Marketplace.Domain.Commands;

namespace Marketplace.Domain.Services
{
    public class ContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IOperacaoRepository _operacaoRepository;

        public ContatoService(IContatoRepository contatoRepository, IOperacaoRepository operacaoRepository)
        {
            _contatoRepository = contatoRepository;
            _operacaoRepository = operacaoRepository;
        }
        private async Task<CntContato> Find(long id)
        {
            var contato = await _contatoRepository.GetById(id);

            if (contato == null)
                throw new Exception("Não existe um contato com o código " + id);

            return contato;
        }
        private async Task UpdateData(CntContato contato, ContatoUpdateCommand request)
        {
            var operacao = await _operacaoRepository.GetById('A') ??
               throw new Exception($"Não existe uma operação cadastrada com o código 'A'");

            contato.Nome = request.Nome;
            contato.Telefone = request.Telefone;
            contato.Email = request.Email;
            // TODO: Propriedades para serem alteradas

        }

        /// Simplificando
        /// Commands - Objeto de entrada de dados.
        /// Queries - Saída de dados.


        // TODO: É necessario a criação de um command
        public async Task<CntContato?> Post(CntContato request)
        {
            return await _contatoRepository.Post(request);
        }

        //public async Task<ContatoInfraQuery?> Create(ContatoCreateCommand request)
        //{
        //    return await _contatoRepository.CreateAsync(request);
        //}

        public Task<ContatoInfraQuery?> GetByIdInfraQuery(long id)
        {
            return _contatoRepository.GetByIdInfraQuery(id);
        }
        public async Task UpdateAsync(long id, ContatoUpdateCommand request)
        {
            var contato = await Find(id);

            await UpdateData(contato, request);

            await _contatoRepository.Update(id, contato);
        }

        public Task<IEnumerable<CntContato>> Get()
        {
            return _contatoRepository.Get();
        }
        public Task<CntContato?> GetById(long id)
        {
            return _contatoRepository.GetById(id);
        }
        public async Task Update(long id, ContatoUpdateCommand request)
        {
            var contato = await Find(id);

            await UpdateData(contato, request);

            await _contatoRepository.Update(id, contato);
        }
        public async Task Delete(long id)
        {
            var contato = await Find(id);

            await _contatoRepository.Delete(contato);    

        }

        public async Task DeleteAsync(long id)
        {
            var contato = await Find(id);

            await _contatoRepository.Delete(contato);

        }
    }
}
