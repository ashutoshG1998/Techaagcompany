using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace Techkidda.BookShop.API.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }
        public Point Location { get; set; }

    }
}
