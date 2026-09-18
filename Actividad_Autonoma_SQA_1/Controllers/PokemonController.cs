using Microsoft.AspNetCore.Mvc;
using Actividad_Autonoma_SQA_1.Services;

namespace Actividad_Autonoma_SQA_1.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 12;
            var allPokemons = await _pokemonService.GetPokemonsAsync();

            int totalItems = allPokemons.Count;
            var paginatedPokemons = allPokemons
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return View(paginatedPokemons);
        }

        public async Task<IActionResult> Details(string id)
        {
            var pokemon = await _pokemonService.GetPokemonDetailAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }
    }
}