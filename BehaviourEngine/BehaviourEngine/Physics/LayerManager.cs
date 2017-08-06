using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class LayerManager
    {
        public const uint DefaultLayer = 1;
        public const uint DefaultMask  = uint.MaxValue;

        private static Dictionary<uint, uint> layers;

        static LayerManager()
        {
            layers = new Dictionary<uint, uint>
            {
                { DefaultLayer, DefaultMask }
            };
        }

        public static void AddLayer(uint layer, uint mask)
        {
            if (!layers.ContainsKey(layer))
            {
                layers.Add(layer, mask);
            }
        }
        public static uint GetMask(uint layer)
        {
            if (layers.ContainsKey(layer))
            {
                return layers[layer];
            }
            return DefaultMask;
        }

        internal static bool CanCollide(CollisionPair2D collisionPair2D)
        {
            uint layer1 = collisionPair2D.collider1.Owner.Layer;
            uint layer2 = collisionPair2D.collider2.Owner.Layer;

            bool x = (layer1 & GetMask(layer2)) != 0 && (layer2 & GetMask(layer1)) != 0;
            return x; 
        }
    }
}
