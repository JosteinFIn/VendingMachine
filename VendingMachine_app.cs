using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine {
	public class VendingMachine_app
    {
        //Fields
        private static int money;
        private static List<Confectionery> inventory;
        //Constructor
		public VendingMachine_app()
		{
            inventory = InventoryInit();
		}

        public void Start()
        {
			while (true)
            {
                inventory.OrderByDescending(x => x.Nr);

                string input = VendingMachine_gui.Menu(money);

                //Get selection and item
                string selection = input.Split().Last();
                string itemType = input.Replace(selection, "").Trim();

                PerformAction(selection, itemType);
                if (input.StartsWith("insert"))
                {
                    //Add to credit
                    money += int.Parse(input.Split(' ')[1]);
                    Console.WriteLine("Adding " + int.Parse(input.Split(' ')[1]) + " to credit");
                }
                if (input.StartsWith("order"))
                {
                    // split string on space
                    var conf = input.Split(' ')[1];
                    //Find out witch kind
                    switch (conf)
                    {
                        case "snickers":
                            var snickers = inventory[0];
                            if (snickers.Name == conf && money > 19 && snickers.Nr > 0)
                            {
                                Console.WriteLine("Giving snickers out");
                                money -= 20;
                                Console.WriteLine("Giving " + money + " out in change");
                                money = 0;
                                snickers.Nr--;
                            }
                            else if (snickers.Name == conf && snickers.Nr == 0)
                            {
                                Console.WriteLine("No snickers left");
                            }
                            else if (snickers.Name == conf)
                            {
                                Console.WriteLine("Need " + (20 - money) + " more");
                            }

                            break;
                        case "milkyway":
                            var milkyway = inventory[2];
                            if (milkyway.Name == conf && money > 14 && milkyway.Nr >= 0)
                            {
                                Console.WriteLine("Giving milkyway out");
                                money -= 15;
                                Console.WriteLine("Giving " + money + " out in change");
                                money = 0;
                                milkyway.Nr--;
                            }
                            else if (milkyway.Name == conf && milkyway.Nr == 0)
                            {
                                Console.WriteLine("No milkyway left");
                            }
                            else if (milkyway.Name == conf)
                            {
                                Console.WriteLine("Need " + (15 - money) + " more");
                            }

                            break;
                        case "kitkat":
                            var kitkat = inventory[1];
                            if (kitkat.Name == conf && money > 14 && kitkat.Nr > 0)
                            {
                                Console.WriteLine("Giving kitkat out");
                                money -= 15;
                                Console.WriteLine("Giving " + money + " out in change");
                                money = 0;
                                kitkat.Nr--;
                            }
                            else if (kitkat.Name == conf && kitkat.Nr == 0)
                            {
                                Console.WriteLine("No kitkat left");
                            }
                            else if (kitkat.Name == conf)
                            {
                                Console.WriteLine("Need " + (15 - money) + " more");
                            }
                            break;
                        default:
                            Console.WriteLine("No such confectionery");
                            break;
                    }
                }
                if (input.StartsWith("sms order"))
                {
                    var conf = input.Split(' ')[2];
                    //Find out witch kind
                    switch (conf)
                    {
                        case "snickers":
                            if (inventory[0].Nr > 0)
                            {
                                Console.WriteLine("Giving snickers out");
                                inventory[0].Nr--;
                            }
                            break;
                        case "kitkat":
                            if (inventory[1].Nr > 0)
                            {
                                Console.WriteLine("Giving kitkat out");
                                inventory[1].Nr--;
                            }
                            break;
                        case "milkyway":
                            if (inventory[2].Nr > 0)
                            {
                                Console.WriteLine("Giving milkyway out");
                                inventory[2].Nr--;
                            }
                            break;
                    }

                }
                if (input.Equals("recall"))
                {
                    //Give money back
                    Console.WriteLine("Returning " + money + " to customer");
                    money = 0;
                }
            }
        }

		private void PerformAction(string selection, string item)
		{
			switch (selection) {
				case "insert":
                    money += int.Parse(item);
                    LogMessage.WriteMessage("Adding " + item + " to credit");
                    return;

                case "order":
                    LogMessage.WriteMessage(Order(item));
                    return;

                default:
			}
		}

		private string Order(string item)
		{
            Confectionery c = inventory.Find(x => x.Name == item);

            if(c.Nr == 0) {
                return ($"No more {c.Name} left");
			}
            if(c.Cost > money) {
                return $"Need " + (c.Cost - money) + " more";
            }

		}

		public string GetConfectionaryNames()
		{
            string items = "";
            inventory.ForEach(x => items += x.Name + ", ");
            items = items.Trim().Remove(items.Length - 2);
            return items;
		}
		private List<Confectionery> InventoryInit()
		{
            return new List<Confectionery>() { new Confectionery { Name = "snickers", Nr = 5, Cost = 20}, 
                                               new Confectionery { Name = "kitkat", Nr = 3, Cost = 15 }, 
                                               new Confectionery { Name = "milkyway", Nr = 3, Cost = 15 } 
                                               //Add additional Confectionaries here
            
                                               };
		}
        private class Confectionery {
            public string Name { get;  set; }
            public int Nr { get;  set; }
            public int Cost { get; set; }
        }
    }
}
