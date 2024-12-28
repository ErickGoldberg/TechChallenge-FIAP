using Contacts.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infraestructure
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider, int maxRetries = 3, TimeSpan? delay = null)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ContactsDbContext>();
                var retries = 0;
                var delayTime = delay ?? TimeSpan.FromSeconds(5);

                while (maxRetries <= retries)
                {
                    try
                    { 
                        await context.Database.MigrateAsync();
                        break;  
                    }
                    catch (Exception ex)
                    {
                        retries++;

                        Console.Error.WriteLine($"Tentativa {retries}/{maxRetries} falhou: {ex.Message}");

                        if (retries >= maxRetries)
                        {
                            Console.Error.WriteLine("Número máximo de tentativas excedido. Lançando exceção.");
                            throw;
                        }

                        await Task.Delay(delayTime);
                    }
                }
            }
        }
    }
}
