using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
	internal class Program
    {
        private static void Main(string[] args)
        {
            VendingMachine_app vendingMachine = new VendingMachine_app();
            vendingMachine.Start();
        }
    }
    /// <summary>
    /// A Confectionary object
    /// </summary>
    public class Confectionery
    {
        public string Name { get; set; }
        public int Nr { get; set; }

    }

}
