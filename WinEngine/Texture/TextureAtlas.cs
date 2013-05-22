using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

using System.Xml;
using System.Xml.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WinEngine.Texture
{
    public class TextureAtlas
    {
        private Texture2D texture;

        public TextureRegion Region(string name)
        {
            if (regions.ContainsKey(name))
            {
                return regions[name];
            }
            return null;
        }

        public Texture2D Texture 
        { 
            get { return texture; } 
            set 
            {
                this.texture = value;

                for (int i = regions.Count - 1; i >= 0; i--)
                {
                    regions.ElementAt(i).Value.Texture = texture;
                }
            } 
        }
        public string Image { get; private set; }

        Dictionary<string, TextureRegion> regions;

        public void LoadContent(string fileName)
        {
            regions = new Dictionary<string, TextureRegion>();

            XDocument xDocument = XDocument.Load(fileName);

            XElement imagePath = xDocument.Element("TextureAtlas");

            string name = imagePath.Attribute("imagePath").Value;
            Image = name.Split('.')[0];

            foreach (var sprite in xDocument.Descendants("sprite"))
            {
                TextureRegion region = new TextureRegion();

                int x = Convert.ToInt16(sprite.Attribute("x").Value);
                int y = Convert.ToInt16(sprite.Attribute("y").Value);
                int w = Convert.ToInt16(sprite.Attribute("w").Value);
                int h = Convert.ToInt16(sprite.Attribute("h").Value);

                int oY = sprite.Attribute("oY") == null ? 0 : Convert.ToInt16(sprite.Attribute("oY").Value);
                int oX = sprite.Attribute("oX") == null ? 0 : Convert.ToInt16(sprite.Attribute("oX").Value);
                int oW = sprite.Attribute("oW") == null ? 0 : Convert.ToInt16(sprite.Attribute("oW").Value);
                int oH = sprite.Attribute("oH") == null ? 0 : Convert.ToInt16(sprite.Attribute("oH").Value);

                region.Bounds = new Rectangle(x, y, w, h);
                region.Rotated = sprite.Attribute("r") != null;

                region.OriginTopLeft = new Vector2(-oX, -oY);
                region.OriginCenter = new Vector2(((oW / 2.0f) - (oX)), ((oH / 2.0f) - (oY)));
                region.OriginBottomRight = new Vector2((oW - (oX)), (oH - (oY)));

                string regionName = sprite.Attribute("n").Value;
                regionName = regionName.Split('.')[0];

                regions[regionName] = region;
            }
        }

    }
}
