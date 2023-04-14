namespace TotalAreaCoveredByRectangles;
public class Kata
{
    public static long Calculate(IEnumerable<int[]> rectangles)
    {

        long totalArea = rectangles
                                  .Select((r, index) => calculateArea(r) - 
                                               calculateOverlappingArea(r, rectangles
                                                                  .Skip(index + 1)
                                                                  .TakeWhile(q => q[0] < r[2] && q[1] < r[3])))
                                  .Sum();

        return totalArea;

        long calculateArea(int[] rectangle){
            return (rectangle[2] - rectangle[0]) * (rectangle[3] - rectangle[1]);
        }

        long calculateOverlappingArea(int[] rectangle, IEnumerable<int[]> overlappingRectangles){
            if (!overlappingRectangles.Any())
                return 0;

            var overlappingPartsOfRectangles = overlappingRectangles
                        .Select(r => new int [] {Math.Max(rectangle[0], r[0]),
                                                 Math.Max(rectangle[1], r[1]),
                                                 Math.Min(rectangle[2], r[2]),
                                                 Math.Min(rectangle[3], r[3])});
            var areaOfOverlappingPartsOfRectangles = overlappingPartsOfRectangles
                    .Select(r => calculateArea(r))
                    .Sum();
            
            return areaOfOverlappingPartsOfRectangles - calculateOverlappingArea(overlappingPartsOfRectangles.First(),
                                                                                 overlappingPartsOfRectangles.Skip(1));
        }
    }
}
