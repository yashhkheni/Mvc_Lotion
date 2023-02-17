using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLotion.Data;
using System;
using System.Linq;

namespace MvcLotion.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Lotion.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lotion.AddRange(
                    new Lotion
                    {
                        Ingredients = "hyaluronic acid, urea, Glycerin",
                        SkinType = "Normal",
                        Texture = "creamy",
                        Purpose = "sun protection",
                        Scent = "Strawberry",
                        Price = 12.00M
                    },
                    new Lotion
                    {
                        Ingredients = "Glycerin, hyaluronic acid, urea",
                        SkinType = "Sensitive",
                        Texture = "Gel",
                        Purpose = "Acne Removal",
                        Scent = "Peach",
                        Price = 15.00M
                    },
                    new Lotion
                    {
                        Ingredients = "Retinol, peptides, alpha-hydroxy acids (AHAs), beta-hydroxy acids (BHAs), vitamin C, or niacinamide",
                        SkinType = "Sensitive",
                        Texture = "Gel",
                        Purpose = "Anti-Aging",
                        Scent = "Apple",
                        Price = 20.00M
                    },
                    new Lotion
                    {
                        Ingredients = "Titanium dioxide, zinc oxide, avobenzone, or octinoxate",
                        SkinType = "Sensitive",
                        Texture = "Cream",
                        Purpose = "Sun Protection",
                        Scent = "Papaya",
                        Price = 25.00M
                    },
                    new Lotion
                    {
                        Ingredients = "Colloidal oatmeal, ceramides, urea, or hydrocortisone",
                        SkinType = "Sensitive",
                        Texture = "Gel",
                        Purpose = "Psoriasis",
                        Scent = "Banana",
                        Price = 20.00M
                    },
                    new Lotion
                    {
                        Ingredients = "Glycerin, hyaluronic acid, urea",
                        SkinType = "Sensitive",
                        Texture = "Gel",
                        Purpose = "Acne Removal",
                        Scent = "Apple",
                        Price = 20.00M
                    },
                    new Lotion
                    {
                        Ingredients = " Hydroquinone, kojic acid, or glycolic acid",
                        SkinType = "Sensitive",
                        Texture = "Gel",
                        Purpose = "Skin Lighting",
                        Scent = "Orange",
                        Price = 30.00M
                    },
                    new Lotion
                    {
                        Ingredients = "beta-hydroxy acids (BHAs), vitamin C, or niacinamide",
                        SkinType = "Sensitive",
                        Texture = "Creamy",
                        Purpose = "Anti-Aging",
                        Scent = "Orange",
                        Price = 25.00M
                    },
                    new Lotion
                    {
                        Ingredients = "Glycerin, hyaluronic acid, urea",
                        SkinType = "Sensitive",
                        Texture = "Gel",
                        Purpose = "BlackHead Removal",
                        Scent = "Peach",
                        Price = 20.00M
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
