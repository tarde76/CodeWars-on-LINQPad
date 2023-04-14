namespace TheSupermarketQueue;
public class Kata
{
    public static long QueueTime(int[] customers, int n)
    {
        if (customers.Length == 0)
            return 0;
        if (customers.Length <= n)
            return customers.Max();

        var checkoutTills = customers.Take(n).ToArray<int>();
        var customersQueue = new Queue<int>(customers.Skip(n));
        int timeCounter = 0;

        while (customersQueue.Count != 0)
        {
            var leastTimeToCheckout = checkoutTills.Min();
            timeCounter += leastTimeToCheckout;

            for (int i = 0; i < checkoutTills.Length; i++)
            {
                checkoutTills[i] -= leastTimeToCheckout;
                if (checkoutTills[i] == 0 )
                    customersQueue.TryDequeue(out checkoutTills[i]);
            }
        }

        return timeCounter + checkoutTills.Max();
    }
}
