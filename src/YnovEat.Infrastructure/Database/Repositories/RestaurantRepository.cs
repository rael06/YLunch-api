using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.Services.Database.Repositories;

namespace YnovEat.Infrastructure.Database.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAdmin(User user)
        {
            await _context.RestaurantUsers.AddAsync(new RestaurantOwner
            {
                Id = user.Id,
                User = user
            });
            await _context.SaveChangesAsync();
        }

        public async Task CreateRestaurant(Restaurant restaurant)
        {
            var owner = await _context.RestaurantUsers.FirstAsync(x => x.User.Id.Equals(restaurant.OwnerId));
            owner.RestaurantId = restaurant.Id;
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}