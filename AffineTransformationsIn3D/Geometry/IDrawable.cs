namespace AffineTransformationsIn3D.Geometry
{
    //основа чего-то,что рисуется и изменяется с центром
    public interface IDrawable
    {
        Vector Center { get; }
        void Draw(Graphics3D graphics);
        void Apply(Matrix transformation);
    }
}
