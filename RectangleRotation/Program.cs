using RectangleRotation;
using System.Collections.Generic;

var tests = new List<(int a, int b)> {(a: 6, b: 4),
                                      (a: 30, b: 2),
                                      (a: 8, b: 6),
                                      (a: 16, b: 20)};

foreach (var test in tests)
{
    Console.WriteLine($"Number of points with integral coordinates a={test.a}, b={test.b} :" + 
                      $"{new Kata().RectangleRotation(test.a, test.b)}");
}

