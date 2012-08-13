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
	public class Render : DrawableGameComponent
	{
		List<Sprite> _sprites = new List<Sprite>();
		static Render _instance;
		SpriteBatch _batch = null;
		

		public void AddSprite(Sprite sprite)
		{
			if (sprite != null)
			{
				_sprites.Add(sprite);
			}
		}

		public void RemoveSprite(Sprite sprite)
		{
			_sprites.Remove(sprite);
		}

		public  Render(Game game,GraphicsDevice device)
			: base(game)
		{
			_batch = new SpriteBatch(device);
		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Draw(GameTime gameTime)
		{
			_batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

			foreach (var sprite in _sprites.Where(e=>e.Visible).OrderBy(e => e.Order))
			{
				_batch.Draw(sprite.Texture, sprite.DestRect, sprite.SourceRect, sprite.Color, sprite.Rotation, sprite.Origin, sprite.Effects,
							sprite.LayerDeph);
			}

			_batch.End();
			base.Draw(gameTime);
		}
	}
}
