using SharpKeys.SDK;
using System;

namespace SharpKeys
{
    public class Color
    {
        public static implicit operator KeyColor(Color c)
        {
            return new KeyColor((byte)(c.r * Byte.MaxValue), (byte)(c.g * Byte.MaxValue), (byte)(c.b * Byte.MaxValue));
        }

        public static implicit operator Color(KeyColor c)
        {
            return new Color().Rgb(c.r / (float)Byte.MaxValue, c.g / (float)Byte.MaxValue, c.b / (float)Byte.MaxValue);
        }

        private float r, g, b;
        public float R { get { return r; } set { r = value; UpdateRgb(); } }
        public float G { get { return g; } set { g = value; UpdateRgb(); } }
        public float B { get { return b; } set { b = value; UpdateRgb(); } }

        private float h, s, v;
        public float H { get { return h; } set { h = value; UpdateHsv(); } }
        public float S { get { return s; } set { s = value; UpdateHsv(); } }
        public float V { get { return v; } set { v = value; UpdateHsv(); } }

        public Color Rgb(float? r = null, float? g = null, float? b = null)
        {
            if (r != null)
                this.r = (float)r;
            if (g != null)
                this.g = (float)g;
            if (b != null)
                this.b = (float)b;
            UpdateRgb();
            return this;
        }

        public Color Hsv(float? h = null, float? s = null, float? v = null)
        {
            if (h != null)
                this.h = (float)h;
            if (s != null)
                this.s = (float)s;
            if (v != null)
                this.v = (float)v;
            UpdateHsv();
            return this;
        }

        private void UpdateRgb()
        {
            ClampRgb();
            Rgb2Hsv();
        }

        private void ClampRgb()
        {
            r = Math.Max(0, Math.Min(1, r));
            g = Math.Max(0, Math.Min(1, g));
            b = Math.Max(0, Math.Min(1, b));
        }

        private void UpdateHsv()
        {
            ClampHsv();
            Hsv2Rgb();
        }

        private void ClampHsv()
        {
            h %= 1;
            if (h < 0)
                h += 1;
            s = Math.Max(0, Math.Min(1, s));
            v = Math.Max(0, Math.Min(1, v));
        }

        private void Rgb2Hsv()
        {
            float cMax = Math.Max(r, Math.Max(g, b));
            float cMin = Math.Min(r, Math.Min(g, b));
            float cDelta = cMax - cMin;

            if (cDelta != 0)
            {
                if (r == cMax)
                    h = ((((g - b) / cDelta) + 6) % 6) / 6;
                else if (g == cMax)
                    h = (((b - r) / cDelta) + 2) / 6;
                else if (b == cMax)
                    h = (((r - g) / cDelta) + 4) / 6;
            }
            else
            {
                // Saturation is 0, i.e. grey

                // Uncomment to reset hue
                // hsv_h = 0;
            }

            if (cMax == 0)
                s = 0;
            else
                s = cDelta / cMax;

            v = cMax;
        }

        private void Hsv2Rgb()
        {
            float c = v * s;
            float x = c * (1 - Math.Abs(((h * 6) % 2) - 1));
            float m = v - c;

            if (h < 1/6f)
            {
                r = c; g = x; b = 0;
            }
            else if (h < 2/6f)
            {
                r = x; g = c; b = 0;
            }
            else if (h < 3/6f)
            {
                r = 0; g = c; b = x;
            }
            else if (h < 4/6f)
            {
                r = 0; g = x; b = c;
            }
            else if (h < 5/6f)
            {
                r = x; g = 0; b = c;
            }
            else
            {
                r = c; g = 0; b = x;
            }
            r += m; g += m; b += m;
        }

        public Color Clone()
        {
            return new Color
            {
                r = r,
                g = g,
                b = b,
                h = h,
                s = s,
                v = v
            };
        }

        public override string ToString()
        {
            return $"[RGB[{r}, {g}, {b}], HSV[{h}, {s}, {v}]";
        }
    }
}
