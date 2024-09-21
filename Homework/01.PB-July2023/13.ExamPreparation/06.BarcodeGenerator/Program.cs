using System;

namespace _06.BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barcodeBegin = int.Parse(Console.ReadLine());
            int barcodeEnd = int.Parse(Console.ReadLine());

            int fourthDigitBegin = 0;
            int thirdDigitBegin = 0;
            int secondDigitBegin = 0;
            int firstDigitBegin = 0;

            int fourthDigitEnd = 0;
            int thirdDigitEnd = 0;
            int secondDigitEnd = 0;
            int firstDigitEnd = 0;

            int counter = 4;

            int barcodeBeginTemp = barcodeBegin;
            while (barcodeBeginTemp != 0)
            {
                int currentDigit = barcodeBeginTemp % 10;

                if (counter == 4) { fourthDigitBegin = currentDigit; }
                else if (counter == 3) { thirdDigitBegin = currentDigit; }
                else if (counter == 2) { secondDigitBegin = currentDigit; }
                else if (counter == 1) { firstDigitBegin = currentDigit; }

                counter--;
                barcodeBeginTemp /= 10;
            }

            counter = 4;
            int barcodeEndTemp = barcodeEnd;
            while (barcodeEndTemp != 0)
            {
                int currentDigit = barcodeEndTemp % 10;

                if (counter == 4) { fourthDigitEnd = currentDigit; }
                else if (counter == 3) { thirdDigitEnd = currentDigit; }
                else if (counter == 2) { secondDigitEnd = currentDigit; }
                else if (counter == 1) { firstDigitEnd = currentDigit; }

                counter--;
                barcodeEndTemp /= 10;
            }

            for (int i = barcodeBegin; i <= barcodeEnd; i++)
            {
                bool validBarcode = true;
                int currentBarcode = i;

                counter = 4;
                while (currentBarcode != 0)
                {
                    int currentDigit = currentBarcode % 10;

                    if (currentDigit % 2 == 0)
                    {
                        validBarcode = false;
                        break;
                    }
                    else
                    {
                        if (counter == 4)
                        {
                            if (currentDigit < fourthDigitBegin || currentDigit > fourthDigitEnd)
                            {
                                validBarcode = false;
                                break;
                            }
                        }
                        else if (counter == 3)
                        {
                            if (currentDigit < thirdDigitBegin || currentDigit > thirdDigitEnd)
                            {
                                validBarcode = false;
                                break;
                            }
                        }
                        else if (counter == 2)
                        {
                            if (currentDigit < secondDigitBegin || currentDigit > secondDigitEnd)
                            {
                                validBarcode = false;
                                break;
                            }
                        }
                        else if (counter == 1)
                        {
                            if (currentDigit < firstDigitBegin || currentDigit > firstDigitEnd)
                            {
                                validBarcode = false;
                                break;
                            }
                        }
                    }

                    counter--;
                    currentBarcode /= 10;
                }

                if (validBarcode)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
