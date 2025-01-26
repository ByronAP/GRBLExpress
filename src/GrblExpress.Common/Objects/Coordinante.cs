namespace GrblExpress.Common.Objects
{
    public class Coordinates
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public float U { get; set; }
        public float V { get; set; }
        public float W { get; set; }

        public override bool Equals(Object? obj)
        {
            if (obj is Coordinates other)
            {
                return X == other.X &&
                       Y == other.Y &&
                       Z == other.Z &&
                       A == other.A &&
                       B == other.B &&
                       C == other.C &&
                       U == other.U &&
                       V == other.V &&
                       W == other.W;
            }
            return false;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}, A: {A}, B: {B}, C: {C}, U: {U}, V: {V}, W: {W}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, A, B, C, U, V) + HashCode.Combine(W);
        }
    }
}
