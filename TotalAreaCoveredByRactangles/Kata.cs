namespace TotalAreaCoveredByRectangles;
public class Kata
{
    record Rectangle(int x0, int y0, int x1, int y1);

    public static long Calculate(IEnumerable<int[]> rectangles)
    {
        var orderedRectangles = rectangles.Select(r => new Rectangle(r[0], r[1], r[2], r[3]));
                                        //    .OrderBy(r => r.x0)
                                        //    .ThenBy(r => r.y0)
                                        //    .ThenByDescending(r => r.x1)
                                        //    .ThenByDescending(r => r.y1);

        long totalArea = orderedRectangles
                                  .Select((r, index) => calculateArea(r) - 
                                               calculateOverlappingArea(r, orderedRectangles
                                                                  .Skip(index + 1)
                                                                  .TakeWhile(q => q.x0 < r.x1 && q.y0 < r.y1)))
                                  .Sum();

        return totalArea;

        long calculateArea(Rectangle rectangle){
            var result = (rectangle.x1 - rectangle.x0) * (rectangle.y1 - rectangle.y0);
            return result;
        }

        long calculateOverlappingArea(Rectangle rectangle, IEnumerable<Rectangle> overlappingRectangles){
            if (!overlappingRectangles.Any())
                return 0;

            var overlappingPartsOfRectangles = overlappingRectangles
                        .Select(r => new Rectangle(Math.Max(rectangle.x0, r.x0),
                                                   Math.Max(rectangle.y0, r.y0),
                                                   Math.Min(rectangle.x1, r.x1),
                                                   Math.Min(rectangle.y1, r.y1)));
            var areaOfOverlappingPartsOfRectangles = overlappingPartsOfRectangles
                    .Select(r => calculateArea(r))
                    .Sum();
            
            return areaOfOverlappingPartsOfRectangles - calculateOverlappingArea(overlappingPartsOfRectangles.First(),
                                                                                 overlappingPartsOfRectangles.Skip(1));
        }
    }
}
