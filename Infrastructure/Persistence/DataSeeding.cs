using DomainLayer.Contracts;
using DomainLayer.Models;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeding(StoreDbContext _dbContext,
        UserManager<ApplicationUser> _userManager,
        RoleManager<IdentityRole> _roleManager,
        StoreIdentityDbContext _identityDbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }
                if (!_dbContext.ProductBrands.Any())
                {
                    //var ProductBrandData =await File.ReadAllTextAsync(@"..C:\Users\Num 1\source\repos\E-Commerce.Web\Infrastracture\Persistence\Data\DataSeed\brands.json ");
                    var ProductBrandData = File.OpenRead(@"C:\Users\Num 1\Downloads\C43-G01-API-Session02\Infrastructure\Persistence\Data\DataSeed\brands.json");
                    var ProductBrands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrands is not null && ProductBrands.Any())
                     await   _dbContext.ProductBrands.AddRangeAsync(ProductBrands);
                    await _dbContext.SaveChangesAsync();


                }
                if (!_dbContext.ProductTypes.Any())
                {
                    var ProductTypeData = File.OpenRead(@"C:\Users\Num 1\Downloads\C43-G01-API-Session02\Infrastructure\Persistence\Data\DataSeed\types.json");
                    var ProductTypes =await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                    if (ProductTypes is not null && ProductTypes.Any())
                     await   _dbContext.ProductTypes.AddRangeAsync(ProductTypes);
                    await _dbContext.SaveChangesAsync();

                }
                if (!_dbContext.Products.Any())
                {
                    var ProductData = File.OpenRead(@"C:\Users\Num 1\Downloads\C43-G01-API-Session02\Infrastructure\Persistence\Data\DataSeed\products.json");
                    var Products =await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (Products is not null && Products.Any())
                     await   _dbContext.Products.AddRangeAsync(Products);
                    await _dbContext.SaveChangesAsync();

                }

            }
            catch(Exception ex)
            {

            }
        }

        public async Task IdentityDataSeedAsync()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }
                if (!_userManager.Users.Any())
                {
                    var User01 = new ApplicationUser()
                    {
                        Email = "Mohamed@gmail.com",
                        DisplayName = "Mohamed Tarek",
                        PhoneNumber = "01000000000",
                        UserName = "Mohamed",
                    };
                    var User02 = new ApplicationUser()
                    {
                        Email = "Salma@gmail.com",
                        DisplayName = "Salma Mohamed",
                        PhoneNumber = "01000000000",
                        UserName = "Salma",
                    };
                    await _userManager.CreateAsync(User01, "Password@123");
                    await _userManager.CreateAsync(User02, "Password@123");
                    await _userManager.AddToRoleAsync(User01, "Admin");
                    await _userManager.AddToRoleAsync(User02, "SuperAdmin");

                }
                await _identityDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }    
    
}
