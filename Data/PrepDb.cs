namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("Sending Data");
                context.Platforms.AddRange(
                    new Models.Platform(){
                        Name = "Java",
                        Publisher="Orcale",
                        Cost = "Free"
                    },
                    new Models.Platform(){
                        Name = "Asp",
                        Publisher="Microsoft",
                        Cost = "Free"
                    }
                );
                context.SaveChanges();
            }
            else{
                Console.WriteLine("Data Exist");
            }
        }
    }
}