namespace KocakBlog.UI.Helpers
{
    public static class ReadingTimeHelper
    {
        private const int AverageReadingSpeed = 200; // Ortalama okuma hızı (kelime/dakika)

        public static int CalculateReadingTime(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            // Metindeki kelime sayısını hesaplayın
            int wordCount = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

            // Okuma süresini hesaplayın (dakika cinsinden)
            int readingTime = (int)Math.Ceiling((double)wordCount / AverageReadingSpeed);

            return readingTime;
        }
    }
}