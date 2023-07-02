using System;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Repository
{
	public class PokemonRepository: IPokemonRepository
	{
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
		{
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokemonId);
            if(review.Count()< 0)
            {
                return 0;
            }

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public bool PokemonExists(int pokemonId)
        {
            return _context.Pokemons.Any(p => p.Id == pokemonId);
        }
    }
}

