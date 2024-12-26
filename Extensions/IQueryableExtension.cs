namespace Tabo.Extensions
{
    public static class IQueryableExtension
    {
        public static IEnumerable<T> Random<T>(this IEnumerable<T> query)
        {
            Random random = new Random();
            return query.OrderBy(_=>random.Next());
        }
    }
}
