namespace RectangleRotation;

public class Kata
{
    public int RectangleRotation(int a, int b)
    {
        //int shorterSide = Math.Min(a, b);
        //var horizontalShift = b * Math.Sqrt(2) / 2;
        double angleInDegrees = 45.0; 
        double angleInRadians = angleInDegrees * (Math.PI / 180.0); 
        double cosineValue = Math.Cos(angleInRadians); 

        double verticalShift = b / (2 * cosineValue);
        double horizontalShift = a / (2 * cosineValue);

        bool inRectangleBoundsXPlusYPlus = true, inRectangleBoundsXPlusYMinus = true,
             inRectangleBoundsXMinusYPLus = true, inRectangleBoundsXMinusYMinus = true;

        int result = 0;
        int x = 0, y = 0, stepX = 0, stepY = 0;

        do
        {
            do
            {
                inRectangleBoundsXPlusYPlus = inRectangle((x + stepX, y + stepY));
                inRectangleBoundsXPlusYMinus = stepY != 0 ? inRectangle((x, y - stepY)) : false;
                inRectangleBoundsXMinusYPLus = x != 0 ? inRectangle((x - stepX, y)) : false;
                inRectangleBoundsXMinusYMinus = stepY != 0 && x !=0 ? inRectangle((x - stepX, y - stepY)) : false;

                stepX++;
            } while (inRectangleBoundsXPlusYPlus || inRectangleBoundsXPlusYMinus ||
                    inRectangleBoundsXMinusYPLus || inRectangleBoundsXMinusYMinus);
            stepX = 0;
            stepY++;
            x++; 
            y++;

            inRectangleBoundsXPlusYPlus = inRectangle((x, y));
            inRectangleBoundsXMinusYMinus = stepX != 0 && stepY != 0? inRectangle((x - stepX, y - stepY)) : false;

        } while (inRectangleBoundsXPlusYPlus || inRectangleBoundsXMinusYMinus);

        return result;

        bool inRectangle((int x, int y) point)
        {
            // y = x + a    => y < x + a
            // y = -x + a   => y < -x + a
            // y = x - a    => y > x - a
            // y = -x - a   => y > -x - a

            if (point.y <= point.x + horizontalShift &&        // y < x + a
                point.y >= point.x - horizontalShift &&        // y > x - a
                point.y <= -point.x + verticalShift  &&    // y < -x + a
                point.y >= -point.x - verticalShift)       // y > -x - a
            {
                result++;
                return true;
            };
            return false;
        }
    }
}
