using Lab29MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab29MovieAPI.Controllers
{
	public class ValuesController : ApiController
	{
		public List<Movy> GetMovie()
		{
			MovieEntities db = new MovieEntities();
			List<Movy> movies = db.Movies.ToList();

			return movies;

		}

		public List<Movy> GetMovieByCategory(string id)
		{
			MovieEntities db = new MovieEntities();
			List<Movy> mov = (from m in db.Movies
							  where m.Category.Contains(id)
							  select m).ToList();

			return mov;
		}

		public Movy GetMovieByRandom()
		{
			//create random object 
			Random random = new Random();
			//get copy of data base
			MovieEntities db = new MovieEntities();
			//create list of all movies from data base
			List<Movy> movies = db.Movies.ToList();
			//use random object to generate a random number which is used as an index in my list
			//to pick a random movie to dissplay
			Movy mov = movies[random.Next(0, movies.Count)];
			//return the movie
			return mov;
		}

		public List<Movy> GetRandomMovieByCategory(string id)
		{
			Random random = new Random();
			MovieEntities db = new MovieEntities();
			List<Movy> movies = (from m in db.Movies
								 where m.Category.Contains(id)
								 select m).ToList();

			Movy mov = movies[random.Next(0, movies.Count)];

			return movies;
		}
		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
