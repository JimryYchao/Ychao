using dotnet_learn.SystemDiagnostics.DebugTest;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Collections;
using Ychao;

namespace dotnet_learn
{
    internal class Program
    {
        static BitState bit;
        static void Main(string[] args)
        {
            bit = new BitState(0b_1_0101_1101, 9);
            bit.Mask(new List<int> { 1, 2, 3, 4 });
            Console.WriteLine(bit);

            bit = new BitState(0b_1_0101_1101, 9);
            bit.Close(0b10100);
            Console.WriteLine(bit);

            bit.Open(1 << 4);
            Console.WriteLine(bit);

            bit.Switch(1 << 3);
            Console.WriteLine(bit);

        }
    }
}