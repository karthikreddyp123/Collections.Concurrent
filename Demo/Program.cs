using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection myCol = new NameValueCollection();
            myCol.Add("red", "rojo");
            myCol.Add("green", "verde");
            myCol.Add("blue", "azul");
            myCol.Add("red", "rouge");
           Console.WriteLine(myCol.Get("red"));
            Console.ReadLine();
        }
    }
}
