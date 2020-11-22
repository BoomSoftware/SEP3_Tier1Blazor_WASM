using System.Text;

namespace SEP3_Tier1Blazor_WASM.Shared
{
    public static class StaticFunctions
    {
        public static string GetUserUri(string name)
        {
            StringBuilder stringBuilder = new StringBuilder(name);

            if (name.Contains(" "))
            {
                for (int i = 0; i < stringBuilder.Length; i++)
                {
                    if (stringBuilder[i] == (char) 32)
                    {
                        stringBuilder[i] = '.';
                    }
                }
            }

            name = stringBuilder.ToString();
            return name;
        }
    }
}