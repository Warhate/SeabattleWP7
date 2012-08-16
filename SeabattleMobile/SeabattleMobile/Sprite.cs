using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SeabattleMobile
{
	/// <summary>
	/// This is a game component that implements IUpdateable.
	/// </summary>
	public class Sprite 
	{
		/// <summary>
		/// Order to draw
		/// </summary>
		public int Order { get; set; }

		Texture2D _texture;
		byte _transperent = 255;
		Color _color;
		
		public Texture2D Texture
		{
			get { return _texture; }
			set
			{
				_texture = value;
				Init(value.Width, value.Height);
			}
		}

		public byte Transperent
		{
			get { return _transperent; }
			set
			{
				_transperent = value;
				_color.A = value;
			}
		}

		/// <summary>
		/// Hotspot
		/// </summary>
		public Vector2 Origin { get; set; }
		public Rectangle DestRect { get; set; }
		public Rectangle SourceRect { get; set; }
		public Color Color
		{
			get { return _color; }
			set
			{
				_color = value;
				_color.A = _transperent;
			}
		}
		public SpriteEffects Effects { get; set; }
		public float Rotation { get; set; }
		public float LayerDeph { get; set; }
		public bool Visible { get; set; }

		public Sprite() 
		{

		}

		void Init(int width, int height)
		{
			Origin = new Vector2(width/2.0f,height/2.0f);
			DestRect = new Rectangle(0,0,width,height);
			SourceRect = new Rectangle(0, 0, width, height);
			Color = Color.White;
			Rotation = MathHelper.ToRadians(0.0f);
			Order = 0;
			LayerDeph = 1.0f;
			Visible = true;
			Main.Render.AddSprite(this);
		}
	}
}
