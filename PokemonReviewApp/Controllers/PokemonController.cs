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

			return Ok(pokemons);
		}
	}
}

