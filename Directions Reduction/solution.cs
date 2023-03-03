using System;
using System.Linq;
using System.Collections.Generic;
public class DirReduction {
  
    public static string[] dirReduc(String[] arr) {
      
      var oppositeDirections = new Dictionary<string, string> {{"NORTH", "SOUTH"}, {"EAST", "WEST"}};

      return arr.Aggregate(Enumerable.Empty<string>(),
						(verifiedDirections, nextDirection) => 
                           checkIfOppositeDirections(verifiedDirections.LastOrDefault(), nextDirection) ? 
                           verifiedDirections.SkipLast(1) : 
                           verifiedDirections.Append(nextDirection)).ToArray();

      bool checkIfOppositeDirections(string firstDirection, string secondDirection) =>
			    (!String.IsNullOrWhiteSpace(firstDirection)) &&
					oppositeDirections.Any(x => (x.Key == firstDirection && x.Value == secondDirection) ||
												(x.Key == secondDirection && x.Value == firstDirection));
    
    }
}