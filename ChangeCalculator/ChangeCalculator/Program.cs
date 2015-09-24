using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator
{
    class Program
    {
        private static decimal getInputDecimal(string message, bool positiveNumber = false, bool acceptZero = true)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(message);

                    string input = Console.ReadLine();

                    decimal response = decimal.Parse(input);

                    if (positiveNumber == true && response <= 0)
                    {
                        Console.WriteLine("Please enter a positive number");

                        continue;
                    }
                    if (acceptZero == false && response < 0)
                    {
                        Console.WriteLine("Please enter a number other than 0");

                        continue;
                    }
                    return response;
                }
                catch (ArgumentNullException a)
                {
                    Console.WriteLine("Please enter a value");
                }
                catch (FormatException b)
                {
                    Console.WriteLine("Please enter a numerical value");
                }
                catch (OverflowException c)
                {
                    Console.WriteLine("Your number is too large");
                }
                catch (Exception d)
                {
                    Console.WriteLine("Error, please try again");
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //Runs through method
                decimal itemCost = getInputDecimal("How much does the item cost?", true, false);

                decimal moneyGiven = getInputDecimal("How much has the customer given you?", true, false);
                
                //Rounds the responses
                decimal roundedCost = Math.Round(itemCost, 2, MidpointRounding.ToEven);

                decimal roundedMoneyGiven = Math.Round(moneyGiven, 2, MidpointRounding.ToEven);

                //Gives me the change needed and uses Math.Floor to give the amount of types needed
                decimal change = roundedMoneyGiven - roundedCost;
                
                decimal numberOfTwenties = Math.Floor(change / 20.00M);

                decimal numberOfTens = Math.Floor((change % 20.00M) / 10.00M);

                decimal numberOfFives = Math.Floor(((change % 20.00M) % 10.00M) / 5.00M);

                decimal numberOfOnes = Math.Floor((((change % 20.00M) % 10.00M) % 5.00M) / 1.00M);

                decimal numberOfQuarters = Math.Floor(((((change % 20.00M) % 10.00M) % 5.00M) % 1.00M) / 0.25M);

                decimal numberOfDimes = Math.Floor((((((change % 20.00M) % 10.00M) % 5.00M) % 1.00M) % 0.25M) / 0.10M);

                decimal numberOfNickels = Math.Floor(((((((change % 20.00M) % 10.00M) % 5.00M) % 1.00M) % 0.25M) % 0.10M) / 0.05M);

                decimal numberOfPennies = Math.Floor((((((((change % 20.00M) % 10.00M) % 5.00M) % 1.00M) % 0.25M) % 0.10M) % 0.05M) / 0.01M);

                //Gives user the answer
                Console.WriteLine("-----------------------------");

                Console.WriteLine("The customer's change is: " + change.ToString("C"));

                Console.WriteLine("Twenty dollar bills: " + numberOfTwenties);

                Console.WriteLine("Ten dollar bills: " + numberOfTens);

                Console.WriteLine("Five dollar bils: " + numberOfFives);

                Console.WriteLine("One dollar bills: " + numberOfOnes);

                Console.WriteLine("Quarters: " + numberOfQuarters);

                Console.WriteLine("Dimes: " + numberOfDimes);

                Console.WriteLine("Nickels: " + numberOfNickels);

                Console.WriteLine("Pennies: " + numberOfPennies);

                Console.WriteLine("-----------------------------");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, please try again");
            }

        }
    }
}




    
