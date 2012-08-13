using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace SeabattleMobile
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Main : Game
	{
		GraphicsDeviceManager graphics;
		Sprite _sprite = new Sprite();
		Sprite _sprite2 = new Sprite();
		Grid _mainGrid;
		
		public static Render Render { get; private set; }


		public Main()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			// Frame rate is 30 fps by default for Windows Phone.
			TargetElapsedTime = TimeSpan.FromTicks(333333);

			// Extend battery life under lock.
			InactiveSleepTime = TimeSpan.FromSeconds(1);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			Render = new Render(this,GraphicsDevice);
			Render.Initialize();
			Components.Add(Render);

			_mainGrid = new Grid(this);
			_mainGrid.Initialize();

			_sprite.Texture = Content.Load<Texture2D>("spell_holy_greaterheal");
			_sprite2.Texture = Content.Load<Texture2D>("spell_holy_greaterheal");

			_sprite.DestRect = new Rectangle(150,150,56,56);
			_sprite2.DestRect = new Rectangle(150 + 5, 150 + 5, 56, 56);

			_sprite2.Color = Color.Red;
			//_sprite2.DestRect = new Rectangle(_sprite2.DestRect.X + 5, _sprite2.DestRect.Y + 5, _sprite2.DestRect.Width, _sprite2.DestRect.Height);
			//_sprite2.SourceRect = new Rectangle(_sprite2.DestRect.X + 5, _sprite2.DestRect.Y + 5, _sprite2.DestRect.Width, _sprite2.DestRect.Height);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{

		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
				this.Exit();

			TouchCollection touchCollection = TouchPanel.GetState();
			foreach (TouchLocation tl in touchCollection)
			{
				if ((tl.State == TouchLocationState.Pressed)
						|| (tl.State == TouchLocationState.Moved))
				{
					_sprite.Order = 12;
					_sprite.Transperent = 150;
					_sprite2.Order = 11;
				}
				else
				{
					_sprite.Order = 11;
					_sprite.Transperent = 0;
					_sprite2.Order = 12;
				}
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);
		}
	}
}
