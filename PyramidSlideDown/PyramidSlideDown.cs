using System.Linq;

namespace PyramidSlideDown;
public class PyramidSlideDown
{
    public static int LongestSlideDown(int[][] pyramid)
    {
        int[] results = pyramid[^1];

        for (int i = pyramid.Length - 2; i >= 0; i--)
        {
            int[] currentRow = pyramid[i];

            var currentResults = 
                currentRow.Select((x, index) => x + Math.Max(results[index], results[index + 1]))
                          .ToArray<int>();
                                            
            results = currentResults;
        }

        return results[0];
    }
}
