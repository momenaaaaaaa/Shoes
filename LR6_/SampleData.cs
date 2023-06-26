using System.Numerics;
using LR6_.Models;

namespace LR6_
{
    public class SampleData 
    {
        public static void Initialize(MobileContext context, IWebHostEnvironment env)
        {
            if (!context.Shoes.Any())
            {
                context.Shoes.AddRange(
                    new Shoes
                    {
                        Name = "Air Force 1 Black",
                        Company = "Nike",
                        Price = 7000,
                    },
                    new Shoes
                    {
                        Name = "Air Force 1 White",
                        Company = "Nike",
                        Price = 8900
                    },
                    new Shoes
                    {
                        Name = "Air Force 1 Purple",
                        Company = "Nike",
                        Price = 7900
                    },
                    new Shoes
                    {
                        Name = "Air Force 1 Low White",
                        Company = "Nike",
                        Price = 6700
                    },
                    new Shoes
                    {
                        Name = "Air Force 1 07 QS Pink",
                        Company = "Nike",
                        Price = 4900
                    }
                );

            }

            context.SaveChanges();
        }
    }
}
