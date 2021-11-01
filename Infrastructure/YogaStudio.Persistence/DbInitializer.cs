namespace YogaStudio.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(YogaStudioDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
