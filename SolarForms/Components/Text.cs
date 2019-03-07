using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    /*
    class Text
    {
        private const string Characters = @"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789µ§½!""#¤%&/()=?^*@£€${[]}\~¨'-_.:,;<>|°©®±¥";
        public Bitmap GenerateCharacters(int fontSize, string fontName, out Size charSize)
        {
            var characters = new List<Bitmap>();
            using (var font = new Font(fontName, fontSize))
            {
                for (int i = 0; i < Characters.Length; i++)
                {
                    var charBmp = GenerateCharacter(font, Characters[i]);
                    characters.Add(charBmp);
                }
                charSize = new Size(characters.Max(x => x.Width), characters.Max(x => x.Height));
                var charMap = new Bitmap(charSize.Width * characters.Count, charSize.Height);
                using (var gfx = Graphics.FromImage(charMap))
                {
                    gfx.FillRectangle(Brushes.Black, 0, 0, charMap.Width, charMap.Height);
                    for (int i = 0; i < characters.Count; i++)
                    {
                        var c = characters[i];
                        gfx.DrawImageUnscaled(c, i * charSize.Width, 0);

                        c.Dispose();
                    }
                }
                return charMap;
            }
        }

        private Bitmap GenerateCharacter(Font font, char c)
        {
            var size = GetSize(font, c);
            var bmp = new Bitmap((int)size.Width, (int)size.Height);
            using (var gfx = Graphics.FromImage(bmp))
            {
                gfx.FillRectangle(Brushes.Black, 0, 0, bmp.Width, bmp.Height);
                gfx.DrawString(c.ToString(), font, Brushes.White, 0, 0);
            }
            return bmp;
        }
        private SizeF GetSize(Font font, char c)
        {
            using (var bmp = new Bitmap(512, 512))
            {
                using (var gfx = Graphics.FromImage(bmp))
                {
                    return gfx.MeasureString(c.ToString(), font);
                }
            }
        }
    }

    public class RenderText : RenderObject
    {
        private readonly Vector4 _color;
        public const string Characters = @"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789µ§½!""#¤%&/()=?^*@£€${[]}\~¨'-_.:,;<>|°©®±¥";
        private static readonly Dictionary<char, int> Lookup;
        public static readonly float CharacterWidthNormalized;
        // 21x48 per char, 
        public readonly List<RenderCharacter> Text;
        static RenderText()
        {
            Lookup = new Dictionary<char, int>();
            for (int i = 0; i < Characters.Length; i++)
            {
                if (!Lookup.ContainsKey(Characters[i]))
                    Lookup.Add(Characters[i], i);
            }
            CharacterWidthNormalized = 1f / Characters.Length;
        }
        public RenderText(ARenderable model, Vector4 position, Color4 color, string value)
            : base(model, position, Vector4.Zero, Vector4.Zero, 0)
        {
            _color = new Vector4(color.R, color.G, color.B, color.A);
            Text = new List<RenderCharacter>(value.Length);
            _scale = new Vector3(0.02f);
            SetText(value);
        }

        public void SetText(string value)
        {
            Text.Clear();
            for (int i = 0; i < value.Length; i++)
            {
                int offset;
                if (Lookup.TryGetValue(value[i], out offset))
                {
                    var c = new RenderCharacter(Model,
                        new Vector4(_position.X + (i * 0.015f),
                            _position.Y,
                            _position.Z,
                            _position.W),
                        (offset * CharacterWidthNormalized));
                    c.SetScale(_scale);
                    Text.Add(c);
                }
            }
        }
        public override void Render(ICamera camera)
        {
            _model.Bind();
            GL.VertexAttrib4(3, _color);
            for (int i = 0; i < Text.Count; i++)
            {
                var c = Text[i];
                c.Render(camera);
            }
        }
    }
    */
}
