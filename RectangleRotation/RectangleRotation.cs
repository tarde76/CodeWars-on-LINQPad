namespace RectangleRotation;

public class Kata
{
    public int RectangleRotation(int a, int b)
    {
        int result = 0;
        int x = 0, y = 0;

        //int shorterSide = Math.Min(a, b);
        var horizontalShift = b * Math.Sqrt(2) / 2;
        var verticalShift = a * Math.Sqrt(2) / 2;;

        int stepY = 0, stepX = 0;
        bool inRectangleBoundsXPlusYPlus = true, inRectangleBoundsXPlusYMinus = true,
             inRectangleBoundsXMinusYPLus = true, inRectangleBoundsXMinusYMinus = true;

        do
        {
            do
            {
                inRectangleBoundsXPlusYPlus = inRectangle(x + stepX, y + stepY);
                inRectangleBoundsXPlusYMinus = stepY != 0 ? inRectangle(x + stepX, y - stepY) : false;
                inRectangleBoundsXMinusYPLus = stepX != 0 ? inRectangle(x - stepX, y + stepY) : false;
                inRectangleBoundsXMinusYMinus = stepY != 0 ? inRectangle(x - stepX, y - stepY) : false;

                stepX++;
            } while (inRectangleBoundsXPlusYPlus || inRectangleBoundsXPlusYMinus ||
                    inRectangleBoundsXMinusYPLus || inRectangleBoundsXMinusYMinus);
            stepY++;
            stepX = 0;

            inRectangleBoundsXPlusYPlus = inRectangle(x + stepX, y + stepY);
            inRectangleBoundsXMinusYMinus = stepY != 0 ? inRectangle(x - stepX, y - stepY) : false;

        } while (inRectangleBoundsXPlusYPlus || inRectangleBoundsXMinusYMinus);

        return result;

        bool inRectangle(int x, int y)
        {
            // y = x + a    => y < x + a
            // y = -x + a   => y < -x + a
            // y = x - a    => y > x - a
            // y = -x - a   => y > -x - a

            if (y <= x + horizontalShift &&        // y < x + a
                y >= x - horizontalShift &&        // y > x - a
                y <= -x + verticalShift  &&    // y < -x + a
                y >= -x - verticalShift)       // y > -x - a
            {
                result++;
                return true;
            };
            return false;
        }
    }
}
