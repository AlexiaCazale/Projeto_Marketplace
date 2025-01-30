using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using System.Data.Common;

namespace Marketplace.Domain.Services
{
    public class OperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }
        private async Task<OprOperacao> Find(char id)
        {
            var operacao = await _operacaoRepository.GetById(id);

            if (operacao == null)
                throw new Exception("Não existe um tipo de transferencia com o código " + id);

            return operacao;
        }

        public Task<OprOperacao?> Post(OprOperacao request)
        {
            var operacao = new OprOperacao();

            //operacao.Codigo = request.Codigo;
            operacao.Descricao = request.Descricao;

            return _operacaoRepository.Post(operacao);
        }
        public Task<IEnumerable<OprOperacao>> Get()
        {
            return _operacaoRepository.Get();
        }
        public Task<OprOperacao?> GetById(char id)
        {
            return _operacaoRepository.GetById(id);
        }
        public async Task Update(char id, OprOperacao request)
        {
            var operacao = await Find(id);

            //operacao.Codigo = request.Codigo;
            operacao.Descricao = request.Descricao;

            await _operacaoRepository.Update(id, operacao);
        }
        public async Task Delete(char id)
        {
            var operacao = await Find(id);
            await _operacaoRepository.Delete(operacao);    

        }
    }
}
