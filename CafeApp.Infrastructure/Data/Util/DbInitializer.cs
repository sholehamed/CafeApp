using CafeApp.Infrastructure.Data.Context;

namespace CafeApp.Infrastructure.Data.Util
{
    internal static class DbInitializer
    {
        internal static void Seed(this CafeDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            //if (dbContext.Roles.Any())
            //    return;
            //var adminRole = new IdentityRole<int>
            //{
            //    Name = UserRoleNames.Admin,
            //    NormalizedName = UserRoleNames.Admin.ToUpper(),
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //};
            //var userRole = new IdentityRole<int>
            //{
            //    Id = 2,
            //    Name = UserRoleNames.User,
            //    NormalizedName = UserRoleNames.User.ToUpper(),
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //};
            //dbContext.Roles.Add(adminRole);
            //dbContext.SaveChanges();
            //UserEntity adminUser = new UserEntity
            //{
            //    ConcurrencyStamp = Guid.NewGuid().ToString(),
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = "deathly",
            //    NormalizedUserName = "deathly".ToUpper(),
            //    FirstName = "حامد",
            //    LastName = "شعله",
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    IsActive = true,
            //};
            //PasswordHasher<UserEntity> hasher = new PasswordHasher<UserEntity>();
            //adminUser.PasswordHash = hasher.HashPassword(adminUser, "hp24121373");
            //dbContext.Users.Add(adminUser);
            //dbContext.SaveChanges();
            //dbContext.UserRoles.Add(new IdentityUserRole<int>
            //{
            //    RoleId = 1,
            //    UserId = 1,
            //});
            //dbContext.SaveChanges();
        }
    }
}
