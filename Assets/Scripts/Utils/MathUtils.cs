using UnityEngine;

namespace Clock.Utils
{
    public static class MathUtils
    {
        public static float SignedAngle(Vector3 vector1, Vector3 vector2, Vector3 normal)
        {
            var angle = Vector3.Angle(vector1, vector2);
            if (Vector3.Dot(normal, Vector3.Cross(vector1, vector2)) < 0)
            {
                angle = -angle;
            }
            return angle;
        }
    }
}