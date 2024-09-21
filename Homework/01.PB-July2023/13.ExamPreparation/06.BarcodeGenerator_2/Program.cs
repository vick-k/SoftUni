using System;

namespace _06.BarcodeGenerator_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barcodeBegin = int.Parse(Console.ReadLine());
            int barcodeEnd = int.Parse(Console.ReadLine());

            int firstDigitBegin = barcodeBegin / 1000;
            int secondDigitBegin = barcodeBegin / 100 % 10;
            int thirdDigitBegin = barcodeBegin / 10 % 10;
            int fourthDigitBegin = barcodeBegin % 10;

            int firstDigitEnd = barcodeEnd / 1000;
            int secondDigitEnd = barcodeEnd / 100 % 10;
            int thirdDigitEnd = barcodeEnd / 10 % 10;
            int fourthDigitEnd = barcodeEnd % 10;

            for (int i1 = firstDigitBegin; i1 <= firstDigitEnd; i1++)
            {
                for (int i2 = secondDigitBegin; i2 <= secondDigitEnd; i2++)
                {
                    for (int i3 = thirdDigitBegin; i3 <= thirdDigitEnd; i3++)
                    {
                        for (int i4 = fourthDigitBegin; i4 <= fourthDigitEnd; i4++)
                        {
                            if (i1 % 2 != 0 && i2 % 2 != 0 && i3 % 2 != 0 && i4 % 2 != 0)
                            {
                                Console.Write($"{i1}{i2}{i3}{i4} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
