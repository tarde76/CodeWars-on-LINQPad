namespace RectangleRotation;

public class Kata
{

    public int RectangleRotation(int a, int b)
    {

        double pointSquareDiagonal = Math.Sqrt(2);
        const int STARTING_POINT = 1;

        var pointsOnEvenLines = 
            (int)(Math.Floor((b / 2) / pointSquareDiagonal) * 2 + STARTING_POINT);
        var numberOfEvenLines = 
            (int)(Math.Floor((a / 2) / pointSquareDiagonal) * 2 + STARTING_POINT);
        var pointsonOddLines = 
            (int)(Math.Floor(((b / 2) - (pointSquareDiagonal / 2)) / pointSquareDiagonal) + STARTING_POINT) * 2;
        var numberofOddLines = 
            (int)(Math.Floor(((a / 2) - (pointSquareDiagonal / 2)) / pointSquareDiagonal) + STARTING_POINT) * 2;

        return (numberOfEvenLines * pointsOnEvenLines) + (numberofOddLines * pointsonOddLines);

    }
}
