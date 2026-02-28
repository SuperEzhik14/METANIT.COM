namespace ClassLibrary4
{
    public class Generic
    {
        public static string Password(string name)
        {
            string str = "";
            for (int i = 0; i < 15; i++)
            {
                if (new Random().Next(2) == 0)
                {
                    str += name[new Random().Next(0, name.Length)];
                }
                else
                {
                    str += new Random().Next(10);
                }
            }
            return str;
        }
    }
}
