﻿using System;
using System.Drawing;
using Mpdn.RenderScript;
using SharpDX;

namespace Mpdn.RenderScripts
{
    namespace Example
    {
        public class CustomTextures : RenderChain
        {
            private ITexture m_Texture1;
            private ITexture m_Texture2;

            protected override string ShaderPath
            {
                get { return "Examples"; }
            }

            public override IFilter CreateFilter(IResizeableFilter sourceFilter)
            {
                CreateTextures();
                var shader = CompileShader("CustomTextures.hlsl");
                return new ShaderFilter(shader, sourceFilter, new TextureSourceFilter(m_Texture1),
                    new TextureSourceFilter(m_Texture2));
            }

            public override void RenderScriptDisposed()
            {
                DiscardTextures();

                base.RenderScriptDisposed();
            }

            private void DiscardTextures()
            {
                DisposeHelper.Dispose(m_Texture1);
                m_Texture1 = null;
                DisposeHelper.Dispose(m_Texture2);
                m_Texture2 = null;
            }

            private void CreateTextures()
            {
                CreateTexture1();
                CreateTexture2();
            }

            private void CreateTexture1()
            {
                if (m_Texture1 != null)
                    return;

                const int width = 10;
                const int height = 10;
                m_Texture1 = CreateTexture(width, height);
            }

            private void CreateTexture2()
            {
                if (m_Texture2 != null)
                    return;

                const int width = 40;
                const int height = 40;
                m_Texture2 = CreateTexture(width, height);
            }

            private static ITexture CreateTexture(int width, int height)
            {
                int pitch = width*4;
                var result = Renderer.CreateTexture(new Size(width, height));
                var tex = GenerateChequeredPattern(pitch, height);
                Renderer.UpdateTexture(result, tex);
                return result;
            }

            private static Half[] GenerateChequeredPattern(int pitch, int height)
            {
                var tex = new Half[pitch * height]; // 16-bit per channel, 4 channels per pixel
                var color0 = new Half[] { 0, 0, 0, 0 };
                var color1 = new Half[] { 0.1f, 0.1f, 0.1f, 0 };
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < pitch; i += 4)
                    {
                        // Fill texture with chequered pattern
                        var c = (i / 4 + j) % 2 == 0 ? color0 : color1;
                        tex[j * pitch + (i + 0)] = c[0];
                        tex[j * pitch + (i + 1)] = c[1];
                        tex[j * pitch + (i + 2)] = c[2];
                        tex[j * pitch + (i + 3)] = c[3];
                    }
                }
                return tex;
            }
        }

        public class CustomTexturesExample : RenderChainUi<CustomTextures>
        {
            public override ExtensionUiDescriptor Descriptor
            {
                get
                {
                    return new ExtensionUiDescriptor
                    {
                        Name = "Custom Textures Example",
                        Description = "(Example) Use custom textures as overlay",
                        Guid = new Guid("8BE548DE-F426-4249-95CB-879236866A07"),
                        Copyright = "" // Optional field
                    };
                }
            }
        }
    }
}
