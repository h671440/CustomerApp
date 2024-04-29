using AutoMapper;
using CustomerApp.Data;
using CustomerApp.Dataa;
using CustomerApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CustomerApp.Services
{
    public class UserService : IUserService
    {
        private readonly CustomerAppContext dx;
        private readonly IMapper _mapper;

        public UserService(CustomerAppContext dx, IMapper mapper)
        {
            this.dx = dx;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await dx.User.ToListAsync();
            return users;
        }
        /*

       
            // Assuming passwords are hashed - this should ideally use a password hasher
            public async Task<ApplicationUser> ValidateUser(string username, string password)
            {
                var user = await dx.Users.FirstOrDefaultAsync(u => u.Username == username);
                return _mapper.Map<ApplicationUser>(user); // Mapping User to ApplicationUser
            }

        }
        */
    }
}