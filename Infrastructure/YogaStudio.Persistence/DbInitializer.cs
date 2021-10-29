namespace YogaStudio.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(YogaStudioDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
