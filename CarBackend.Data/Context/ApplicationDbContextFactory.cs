using CarBackend.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CarBackend.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // 1. تحديد مسار مجلد الـ Presentation بدقة
            // نفترض أننا ننفذ الأمر من المجلد الرئيسي للمشروع (CarBackend)
            var basePath = Directory.GetCurrentDirectory();

            // نحاول الوصول لمجلد Presentation بشكل صريح
            // نقوم بالبحث عن appsettings.json في المسار المتوقع
            var configPath = Path.Combine(basePath, "CarBackend.presentation");

            // تحقق بسيط: إذا لم يجد المجلد، جرب المجلد الحالي (fallback)
            if (!Directory.Exists(configPath))
            {
                configPath = basePath;
            }

            Console.WriteLine($"🔍 DEBUG: Looking for config in: {configPath}");

            // 2. بناء الإعدادات (نقرأ appsettings.json فقط لتجنب مشاكل الـ Development Override أثناء الـ Migration)
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 3. جلب الـ Connection String
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // طباعة العنوان الذي وجده الكود (مهم جداً للتشخيص)
            Console.WriteLine($"🔍 DEBUG: Connection String Found!");
            Console.WriteLine($"🌍 Host being used: {GetHostFromConnString(connectionString)}");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        // دالة مساعدة لاستخراج اسم السيرفر فقط لغرض الطباعة
        private string GetHostFromConnString(string connString)
        {
            if (string.IsNullOrEmpty(connString)) return "⚠️ EMPTY or NULL";
            try
            {
                var parts = connString.Split(';');
                foreach (var part in parts)
                {
                    if (part.Trim().StartsWith("Host", StringComparison.OrdinalIgnoreCase) ||
                        part.Trim().StartsWith("Server", StringComparison.OrdinalIgnoreCase))
                    {
                        return part.Split('=')[1];
                    }
                }
                return "❓ Host parameter not found";
            }
            catch
            {
                return "⚠️ Error parsing string";
            }
        }
    }
}