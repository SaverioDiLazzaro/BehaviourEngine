using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace BehaviourEngine
{
    public static class TextureManager
    {
        private static Dictionary<string, Texture> textures;
        static TextureManager()
        {
            textures = new Dictionary<string, Texture>();
        }

        public static void AddTexture(string name, Texture texture)
        {
            if (!textures.ContainsKey(name))
            {
                textures.Add(name, texture);
            }
        }

        public static Texture GetTexture(string name)
        {
            if (textures.ContainsKey(name))
            {
                return textures[name];
            }
            return null;
        }
    }
}
