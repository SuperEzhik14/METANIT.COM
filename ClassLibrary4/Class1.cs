namespace ClassLibrary4
{
    public class Text
    {
        public static string ConvertToInt32(int obj)
        {
            if (obj.ToString().Length > 10)
            {
                return obj.ToString();
            }
            string str = null;

            for (int i = obj.ToString().Length; i < 10; i++)
            {
                str += "0";
            }

            str = obj.ToString();

            return str;
        }

        public static string ConvertName_LastName(int count, string name = null, string lastname = null)
        {
            
            string str = null;

            str += name;
            str += " ";
            str += lastname
                ;
            for (int i = str.Length; i < count; i++)
            {
                str += " ";
            }

            
            return str;
        }
    }
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
        public static char Simvol()
        {
            switch (new Random().Next(12))
            {
                case 0: return '!';
                case 1: return '|';
                case 2: return '*';
                case 3: return '%';
                case 4: return '#';
                case 5: return '$';
                case 6: return '@';
                case 7: return 'H';
                case 8: return '=';
                case 9: return '^';
                case 10: return '-';
                case 11: return '?';
                default: return ' ';
            }
        }
    }
}
