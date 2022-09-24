namespace ITechArt.Functions
{
    public static class Values
    {
        public static string GetString(string word)
        {
            if (word is "-")
            {
                return null;
            }
            else
            {
                return word;
            }
        }
        public static int GetInt(string word)
        {
            int result = 0;
            if (word is "-")
            {
                return 0;
            }
            else
            {
                int.TryParse(word, out result);
                return result;
            }
        }
    }
}
