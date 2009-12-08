using System;
using Microsoft.Xna.Framework;
namespace XRealEngine.Framework.Services
{
    interface ICamera2D
    {
        Vector2 Position { get; set; }
        float Rotation { get; set; }
        Matrix TransformationMatrix { get; }
        float Zoom { get; set; }
    }
}
