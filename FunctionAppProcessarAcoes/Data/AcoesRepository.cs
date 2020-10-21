using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using FunctionAppProcessarAcoes.Models;

namespace FunctionAppProcessarAcoes.Data
{
    public class AcoesRepository
    {
        private readonly ConnectionMultiplexer _conexaoRedis;
        private readonly string _prefixoChaveRedis;

        public AcoesRepository(IConfiguration configuration)
        {
            _conexaoRedis = ConnectionMultiplexer.Connect(
                configuration["Redis:Connection"]);
            _prefixoChaveRedis = configuration["Redis:PrefixoChave"];
        }

        public void Save(Acao acao)
        {
            _conexaoRedis.GetDatabase().StringSet(
                $"{_prefixoChaveRedis}-{acao.Codigo}",
                JsonSerializer.Serialize(acao),
                expiry: null);
        }
    }
}