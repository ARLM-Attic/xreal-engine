using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRealEngine.Animation
{
    public sealed class BonesCollection
    {
        List<Bone> _bones;
        Bone _parent;

        private BonesCollection()
        {
        }

        internal BonesCollection(Bone bone)
        {
            _parent = bone;
            _bones = new List<Bone>();
        }

        public void Add(Bone bone)
        {
            bone.Parent = _parent;
            _bones.Add(bone);
        }
    }
}
