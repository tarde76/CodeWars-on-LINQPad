using System;
using System.Linq;

public class DirReduction {
  
    public static string[] dirReduc(String[] arr) {
      return arr.Aggregate(Enumerable.Empty<string>(),
						(verifiedDirections, nextDirection) => 
                   verifyOppositeDirection(verifiedDirections.LastOrDefault(), nextDirection) 
                                           ? verifiedDirections.SkipLast(1) 
                                           : verifiedDirections.Append(nextDirection))
            .ToArray();

      bool verifyOppositeDirection(string firstDirection, string secondDirection) =>
	          (firstDirection == "NORTH" && secondDirection == "SOUTH") ||
	          (firstDirection == "SOUTH" && secondDirection == "NORTH") ||
	          (firstDirection == "EAST" && secondDirection == "WEST") ||
	          (firstDirection == "WEST" && secondDirection == "EAST");  

    }
  
}