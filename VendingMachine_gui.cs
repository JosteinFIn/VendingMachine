using System;

namespace VendingMachine {
	public static class VendingMachine_gui {
        public static string Menu(int money)
		{
            string items = new VendingMachine_app().GetConfectionaryNames();

            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine($"order ({items}) - Order from machines buttons");
            Console.WriteLine($"sms order ({items}) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");
            Console.WriteLine("Inserted money: " + money);
            Console.WriteLine("-------\n\n");

            return Console.ReadLine();
        }
	}

}
