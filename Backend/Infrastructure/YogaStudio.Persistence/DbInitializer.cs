namespace YogaStudio.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(YogaStudioDbContext context)
        {
            // TODO: Use this method for initialize database with data
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
