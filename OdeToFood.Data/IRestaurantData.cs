using OdeToFood.Cores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's pizza", Location = "Maryland", Cuisine=CuisineType.Italian },
                new Restaurant {Id = 2, Name = "Phillys cuisine", Location = "Chicago", Cuisine = CuisineType.Indian },
                new Restaurant {Id = 3, Name = "My home cafe", Location = "Omaha", Cuisine = CuisineType.None },
                new Restaurant {Id = 4, Name = "La coza nostra", Location = "Russia", Cuisine = CuisineType.Mexican }
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
