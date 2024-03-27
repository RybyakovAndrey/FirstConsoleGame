
namespace ConsoleGameEngine.Domain.Struct
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public static Vector2 Zero => new Vector2(0, 0);
        public Vector2() : this(0, 0) { }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !(a == b);
        }

        public static bool operator >(Vector2 a, Vector2 b)
        {
            return (a.X > b.X) && (a.Y > b.Y);
        }

        public static bool operator <(Vector2 a, Vector2 b)
        {
            return !(a > b) && a != b;
        }

        public static bool operator >=(Vector2 a, Vector2 b)
        {
            return !(a < b);
        }
        public static bool operator <=(Vector2 a, Vector2 b)
        {
            return !(a > b);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator +(Vector2 a, float value)
        {
            return new Vector2(a.X + value, a.Y + value);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator *(Vector2 a, float value)
        {
            return new Vector2(a.X * value, a.Y * value);
        }

        public static Vector2 operator /(Vector2 a, float value)
        {
            if (value == 0)
                return Zero;

            return new Vector2(a.X / value, a.Y / value);
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector2 vector)
                return X.Equals(vector.X) && Y.Equals(vector.Y);

            return false;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() * 31 + Y.GetHashCode();
        }
        public override string ToString()
        {
            return $"({X} : {Y})";
        }
    }
}
