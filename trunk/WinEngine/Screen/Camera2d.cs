using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WinEngine.Screen
{
    public class Camera2d
    {
        //================================================================
        //Constants
        //================================================================

        //================================================================
        //Fields
        //================================================================
        public Matrix tranform;

        protected Vector2 position;

        protected float zoom;
        protected float rotation;

        public readonly int width;
        public readonly int height;

        //================================================================
        //Constructors
        //================================================================
        public Camera2d(int width, int height)
        {
            this.zoom = 1.0f;
            this.rotation = 0.0f;

            this.position = Vector2.Zero;

            this.width = width;
            this.height = height;
        }

        //================================================================
        //Getter and Setter
        //================================================================
        public float Zoom
        {
            get { return this.zoom; }
            set { this.zoom = value; if (zoom < 0.1f) zoom = 0.1f; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public float X
        {
            get { return this.position.X; }
            set { this.position.X = value; }
        }

        public float Y
        {
            get { return this.position.Y; }
            set { this.position.Y = value; }
        }

        public float Rotation
        {
            get { return this.rotation; }
            set { this.rotation = value; }
        }

        //================================================================
        //Methodes
        //================================================================
        public void Move(Vector2 amout)
        {
            this.position += amout;
        }

        public Matrix Transformation()
        {
            tranform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                                         Matrix.CreateRotationZ(rotation) *
                                         Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(width * 0.5f , height * 0.5f, 0));
            return tranform;
        }

        public Vector2 ConvertSceneToWorld(Vector2 vector)
        {
            Matrix matrix = Matrix.Invert(tranform);
            return Vector2.Transform(vector, matrix);
        }

        public void Update()
        {
            Transformation();
        }

        public void Reset()
        {
            zoom = 1.0f;
            rotation = 0.0f;

            Transformation();
        }
        //================================================================
        //Methodes overridde
        //================================================================

        // ===============================================================
        // Inner and Anonymous Classes
        // ===============================================================
    }
}
