using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<AdminLoginResponseModel> GetAdminByIdAsync(int id)
        {
            var response =  await _adminRepository.GetByIdAsync(id);
            if (response == null) return null;
            return new AdminLoginResponseModel()
            {
                Id = response.Id,
                Email = response.EMAIL,
                Name = response.NAME,
                Password = response.HashedPassword
            };
        }

        public async Task<AdminLoginResponseModel> LoginAsync(AdminLoginRequestModel requestModel)
        {
            var dbAdmin = await _adminRepository.GetAdminByEmailAsync(requestModel.Email);
            if (dbAdmin != null)
            {
                var hashedPassword = HashPassword(requestModel.Password, dbAdmin.Salt);
                if (hashedPassword == dbAdmin.HashedPassword)
                {
                    // Correct password
                    var userLoginResponse = new AdminLoginResponseModel
                    {
                        Id = dbAdmin.Id,
                        Email = dbAdmin.EMAIL,
                        Name = dbAdmin.NAME,
                        Password = dbAdmin.HashedPassword
                    };

                    return userLoginResponse;
                }
            }

            return null;

        }

        public async Task<AdminRegisterResponseModel> RegisterUserAsync(AdminRegisterRequestModel requestModel)
        {
            // 1. Make sure the email does not exists in the database User table
            var dbAdmin = await _adminRepository.GetAdminByEmailAsync(requestModel.Email);
            if (dbAdmin != null)
            {
                return null;
            }

            // 2. Create a unique salt for the user password
            var salt = CreateSalt();
            var hashedPassword = HashPassword(requestModel.Password, salt);

            // 3. Save to database
            var admin = new Admin
            {
                EMAIL = requestModel.Email,
                NAME = requestModel.Name,
                Salt = salt,
                HashedPassword = hashedPassword
            };
            var createdUser = await _adminRepository.AddAsync(admin);

            // 4. Map the createdUser to the UserRegisterResponseModel
            var userResponse = new AdminRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.EMAIL,
                Name = createdUser.NAME,
                Password = createdUser.HashedPassword
            };

            return userResponse;
        }

        private string CreateSalt()
        {
            // Never write our own code. Use the standard. 
            // https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-5.0

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string HashPassword(string password, string salt)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            // This Pbkdf2 is US standard 
            // Other protocols are: Aarogon, BCrypt
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
