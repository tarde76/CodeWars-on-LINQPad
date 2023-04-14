namespace TheSupermarketQueue;
public class Kata
{
    public static long QueueTime(int[] customers, int n)
    {
        var checkoutTill = new int[n];
        var customersQueue = new Queue<int>(customers);

        for (int i = 0; i < checkoutTill.Length; i++)
        {
            customersQueue.TryDequeue(out checkoutTill[i]);
            if (customersQueue.Count == 0)
                return checkoutTill.Max();
        }

        int timeCounter = 0;

        while (customersQueue.Count != 0)
        {
            var leastTimeToCheckout = checkoutTill.Min();
            timeCounter += leastTimeToCheckout;
            for (int i = 0; i < checkoutTill.Length; i++)
            {
                checkoutTill[i] -= leastTimeToCheckout;
                if (checkoutTill[i] == 0 )
                    customersQueue.TryDequeue(out checkoutTill[i]);
            }
        }

        return timeCounter + checkoutTill.Max();
    }
}
