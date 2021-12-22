using System;

namespace AzureZumoApp.Extensions
{
    static class UriExtensions
    {
        public static Uri ToPluralCollectionNameUri(this Uri uri)
        {
            var path = uri.ToString();
            var pluralPath = "";

            int startIndex = path.IndexOf("/tables/") + 8;
            int questionMarkIndex = path.IndexOf("?", startIndex);

            if (questionMarkIndex == -1)
                pluralPath = path + "s";

            pluralPath = path.Insert(questionMarkIndex, "s");

            return new Uri(pluralPath);
        }
    }
}
