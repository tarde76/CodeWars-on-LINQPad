
using TotalAreaCoveredByRectangles;

Console.WriteLine(Kata.Calculate(new [] { new [] {0,0,1,1}}));

Console.WriteLine(Kata.Calculate(new [] { new [] {0,4,11,6}}));
Console.WriteLine(Kata.Calculate(new [] { new [] {0,0,1,1}, new [] {1,1,2,2}}));
Console.WriteLine(Kata.Calculate((new [] { new [] {0,0,1,1}, new [] {0,0,2,2}})));
Console.WriteLine(Kata.Calculate((new [] { new [] {3,3,8,5}, new [] {6,3,8,9}, new [] {11,6,14,12}})));


// Console.WriteLine(Kata.Calculate(new [] { new [] {0,0,1,1}, new [] {0,4,1,6}}));

// Console.WriteLine(Kata.Calculate(new [] { new [] {0,0,1,1}, new [] {0,0,2,2}}));

// Console.WriteLine(Kata.Calculate(new [] { new [] {3,3,8,5}, new [] {6,3,8,9}, new [] {11,6,14,12}}));

//  Console.WriteLine(Kata.Calculate(new [] { 
//                                 new [] {1,2,4,4}
//                                 , new [] {6,2,10,6}
//                                 , new [] {7,3,9,5}
//                                 }));

 Console.WriteLine(Kata.Calculate(new [] {
                                    new [] {13, 1, 17, 4},
                                    new [] {14, 2, 16, 5},
                                    new [] {15, 3, 21, 6}
                                  }));
