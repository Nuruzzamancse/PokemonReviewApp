using System;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PokemonController: Controller
	{
        private readonly IPokemonRepository _ipokemonRepository;

        public PokemonController(IPokemonRepository ipokemonRepository)
		{
            _ipokemonRepository = ipokemonRepository;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
		public IActionResult GetPokemons()
		{
			var pokemons = _ipokemonRepository.GetPokemons();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemons);
		}

		[HttpGet("{pokemonId}")]
		[ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokemonId)
		{
			if (!_ipokemonRepository.PokemonExists(pokemonId))
				return NotFound();
			

			var pokemon = _ipokemonRepository.GetPokemon(pokemonId);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemon);

		}

        [HttpGet("{pokemonId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokemonId)
        {
            if (!_ipokemonRepository.PokemonExists(pokemonId))
                return NotFound();


            var rating = _ipokemonRepository.GetPokemonRating(pokemonId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);

        }


    }
}

