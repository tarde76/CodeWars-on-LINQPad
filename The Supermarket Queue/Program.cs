using TheSupermarketQueue;

TestCase[] customersCases = {new TestCase(2, new [] {10,2,3,3}),
                             new TestCase(2, new [] {10, 2}),
                             new TestCase(1, new [] {5, 3, 4}),
                             new TestCase(2, new [] {2, 3, 10}),
                             new TestCase(2, new [] {10, 2, 3})};

foreach(var testCase in customersCases)
    Console.WriteLine($"The exepcted time for {testCase.nrOfCheckoutTills} checkout tills is : {Kata.QueueTime(testCase.customerQueue, testCase.nrOfCheckoutTills)}");

record TestCase(int nrOfCheckoutTills, int[] customerQueue);

