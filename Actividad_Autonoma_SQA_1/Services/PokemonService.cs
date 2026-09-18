using Newtonsoft.Json;
using Actividad_Autonoma_SQA_1.Models;

namespace Actividad_Autonoma_SQA_1.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PokemonSummary>> GetPokemonsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=100");
                var apiResponse = JsonConvert.DeserializeObject<PokemonApiResponse>(response);
                return apiResponse?.Results ?? new List<PokemonSummary>();
            }
            catch
            {
                return new List<PokemonSummary>();
            }
        }

        public async Task<PokemonDetail?> GetPokemonDetailAsync(string idOrName)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{idOrName}");
                return JsonConvert.DeserializeObject<PokemonDetail>(response);
            }
            catch
            {
                return null;
            }
        }
    }
}