using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPractick
{
    public interface Status
    {
        string Name { get; }
    }
    public class Classic : Status
    {
        public string Name => "Рядовой";
    }
    public class Deluxe : Status
    {
        public string Name => "Deluxe";
    }
    public class Premium : Status
    {
        public string Name => "Premium";
    }
}
