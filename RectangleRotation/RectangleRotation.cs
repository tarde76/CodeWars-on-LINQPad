namespace RectangleRotation;

public class Kata
{
    public int RectangleRotation(int a, int b)
    {
        double positiveCoefficient, negativeCoefficient;
        calculateFunctionsCoefficients(a, b, out positiveCoefficient, out negativeCoefficient);

        bool anyInRectangle = true;
        int counter = 0;

        return findAllPointsSimplyfied();

        int findAllPointsSimplyfied()
        {
            counter = 1;
            int offset = 1;
            while (anyInRectangle)
            {
                anyInRectangle = inRectangle((0, offset));
                anyInRectangle = inRectangle((0, -offset)) || anyInRectangle;
                offset++;
            }

            int resultForYAxis = counter;
            counter = 0;

            int xMax = (int)Math.Floor((positiveCoefficient + negativeCoefficient) / 2);
            int startY = 0;
            int x = 1;
            while (x <= xMax)
            {
                int? maxYInRange = null, minYInRange = null;
                offset = 0;

                do
                {
                    anyInRectangle = false;
                    if (inRectangle((x, startY + offset)))
                    {
                        anyInRectangle = true;
                        maxYInRange = startY + offset;
                        minYInRange ??= startY + offset;
                    }
                    if (offset > 0 && inRectangle((x, startY - offset)))
                    {
                        anyInRectangle = true;
                        minYInRange = startY - offset;
                    }
                    offset++;
                } while (anyInRectangle || offset == 1);
                if (minYInRange != null && maxYInRange != null)
                    startY = minYInRange.Value + ((maxYInRange.Value - minYInRange.Value) / 2);
                x++;
            }
            return resultForYAxis + (counter * 2);
        }

        bool inRectangle((int x, int y) point)
        {
            if (point.y <= point.x + positiveCoefficient &&
                point.y >= point.x - positiveCoefficient &&
                point.y <= -point.x + negativeCoefficient &&
                point.y >= -point.x - negativeCoefficient)
            {
                counter++;
                return true;
            };
            return false;
        }

        static void calculateFunctionsCoefficients(int a, int b, out double positiveCoefficient, out double negativeCoefficient)
        {
            double angleInDegrees = 45.0;
            double angleInRadians = angleInDegrees * (Math.PI / 180.0);
            double cosineValue = Math.Cos(angleInRadians);

            positiveCoefficient = b / (2 * cosineValue);
            negativeCoefficient = a / (2 * cosineValue);
        }
    }
}
