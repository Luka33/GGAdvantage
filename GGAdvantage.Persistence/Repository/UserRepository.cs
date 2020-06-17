//using GGAdvantage.Application.Interfaces;
//using GGAdvantage.Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace GGAdvantage.Persistence.Repository
//{
//    public class UserRepository : IUserStore<User>, IUserPasswordStore<User>
//    {
//        private readonly GGAdventageDbContext _context;

//        public UserRepository(GGAdventageDbContext context)
//        {
//            _context = context;
//        }

//        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.Id);
//        }

//        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.NormalizedUserName);
//        }

//        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.UserName);
//        }

//        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
//        {
//            var user = _context.User.Find(userId);

//            return Task.FromResult(user);
//        }

//        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
//        {
//            var user = _context.User.SingleOrDefault(_ => _.NormalizedUserName == normalizedUserName);

//            return Task.FromResult(user);
//        }

//        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
//        {
//            try
//            {
//                await _context.User.AddAsync(user);
//                await _context.SaveChangesAsync();

//                return IdentityResult.Success;
//            }
//            catch (Exception)
//            {
//                return IdentityResult.Failed();
//            }

//        }

//        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
//        {
//            try
//            {
//                _context.User.Attach(user);
//                _context.Entry(user).State = EntityState.Modified;
//                await _context.SaveChangesAsync();

//                return IdentityResult.Success;
//            }
//            catch (Exception)
//            {
//                return IdentityResult.Failed();
//            }
//        }

//        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
//        {
//            try
//            {
//                if (_context.Entry(user).State == EntityState.Detached)
//                {
//                    _context.User.Attach(user);
//                }
//                _context.User.Remove(user);

//                await _context.SaveChangesAsync();

//                return IdentityResult.Success;
//            }
//            catch (Exception)
//            {
//                return IdentityResult.Failed();
//            }
        
//        }

//        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
//        {
//            user.NormalizedUserName = normalizedName;

//            return Task.CompletedTask;
//        }

//        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
//        {
//            user.UserName = userName;

//            return Task.CompletedTask;
//        }

//        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
//        {
//            user.PasswordHash = passwordHash;
//            return Task.CompletedTask;
//        }

//        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.PasswordHash);
//        }

//        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
//        {
//            return Task.FromResult(user.PasswordHash != null);
//        }

//        public void Dispose()
//        {
//        }
//    }
//}
