using System;
using System.Collections.Generic;

class Programa
{
    static bool PuestoLimonadasColas(int[] billetes)
    {
        Queue<int> cola5 = new Queue<int>();
        Queue<int> cola10 = new Queue<int>();

        foreach (var billete in billetes)
        {
            if (billete == 5)
            {
                cola5.Enqueue(billete);
            }
            else if (billete == 10)
            {
                if (cola5.Count > 0)
                {
                    cola5.Dequeue(); 
                    cola10.Enqueue(billete); 
                }
                else
                {
                    return false; 
                }
            }
            else if (billete == 20)
            {

                if (cola10.Count > 0 && cola5.Count > 0)
                {
                    cola10.Dequeue();
                    cola5.Dequeue();
                }

                else if (cola5.Count >= 3)
                {
                    cola5.Dequeue();
                    cola5.Dequeue();
                    cola5.Dequeue();
                }
                else
                {
                    return false;
                }
            }
        }
        return true; 
    }

    static void Main()
    {
        Console.WriteLine(PuestoLimonadasColas(new int[] { 5, 5, 5, 10, 20 })); // ➞ true
        Console.WriteLine(PuestoLimonadasColas(new int[] { 5, 5, 10, 10, 20 })); // ➞ false
        Console.WriteLine(PuestoLimonadasColas(new int[] { 10, 10 })); // ➞ false
        Console.WriteLine(PuestoLimonadasColas(new int[] { 5, 5, 10 })); // ➞ true
    }
}

