using System;
using Microsoft.AspNetCore.Identity;
using YnovEat.Domain.DTO.UserModels.Registration;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.ModelsAggregate.UserAggregate
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ConfirmationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public DateTime? PhoneNumberConfirmationDateTime { get; set; }
        public DateTime? EmailConfirmationDateTime { get; set; }
        public bool IsAccountConfirmed => ConfirmationDateTime != null;
        public bool IsAccountActivated { get; set; }
        public virtual RestaurantUser RestaurantUser { get; set; }
        public virtual Customer Customer { get; set; }

        public static User Create(EmployeeCreationDto userCreationDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userCreationDto.Username,
                Lastname = userCreationDto.Lastname,
                Firstname = userCreationDto.Firstname,
                CreationDateTime = DateTime.Now,
            };

            user.RestaurantUser = RestaurantUser.CreateEmployee(user.Id, user.RestaurantUser.RestaurantId);
            return user;
        }

        public static User Create(RestaurantAdminCreationDto userCreationDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userCreationDto.Username,
                Lastname = userCreationDto.Lastname,
                Firstname = userCreationDto.Firstname,
                CreationDateTime = DateTime.Now,
            };

            user.RestaurantUser = RestaurantUser.CreateAdmin(user.Id);
            return user;
        }

        public static User Create(SuperAdminCreationDto userCreationDto)
        {
            return new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userCreationDto.Username,
                Lastname = userCreationDto.Lastname,
                Firstname = userCreationDto.Firstname,
                CreationDateTime = DateTime.Now,
            };
        }

        public static User Create(CustomerCreationDto userCreationDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userCreationDto.Username,
                Lastname = userCreationDto.Lastname,
                Firstname = userCreationDto.Firstname,
                Email = userCreationDto.Username,
                PhoneNumber = userCreationDto.PhoneNumber,
                CreationDateTime = DateTime.Now,
            };
            user.Customer = Customer.Create(user.Id);
            return user;
        }
    }
}
