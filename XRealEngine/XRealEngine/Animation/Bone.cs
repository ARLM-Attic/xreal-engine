using System;
using System.Collections.Generic;

namespace XRealEngine.Animation
{
    public sealed class Bone
    {
        public Bone Parent { get; internal set; }
        public BonesCollection Childs { get; private set; }
        public float Angle { get;set; }
        public string Name { get; set; }
        public float Length { get; set; }

        public Bone(string name, float length, float angle):this()
        {
            Name = name;
            Length = length;
            Angle = angle;
        }

        public Bone()
        {
            Childs = new BonesCollection(this);
            Parent = null;
        }
    }
}
