using BlazorPokedex.Components.Models;
using System.Text.Json;

namespace BlazorPokedex.Utilities
{
    public class PokeClient
    {
		
        public HttpClient Client { get; set; }

        public PokeClient(HttpClient client)
        {
            this.Client = client;
        }

        public async Task<Pokemon> GetPokemon(string id)
        {
            var response = await this.Client.GetAsync($"Https://pokeapi.co/api/v2/pokemon/{id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Pokemon>(content);
        }
	}
}
