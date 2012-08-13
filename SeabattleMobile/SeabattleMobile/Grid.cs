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
	public class Grid : GameComponent
	{

		int GRID_SIZE = 10;

		Texture2D _gridTexture;
		Texture2D _shipTexture;
		Texture2D _missTexture;
		Texture2D _waterTexture;

		int _gridSize = 32;

		public Vector2 Position { get; set; }

		Sprite[,] _gridSprites;
		Sprite[,] _stateSprites;
		bool[,] _shots;
		bool[,] _blocks;

		List<Ship> _ships = new List<Ship>(); 

		public Grid(Game game)
			: base(game)
		{
			_gridSprites = new Sprite[GRID_SIZE,GRID_SIZE];
			Position = new Vector2(50,50);
		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			_gridTexture = Game.Content.Load<Texture2D>("grid");
			
			for (int i = 0; i < _gridSprites.GetLength(0); i++)
			{
				for (int j = 0; j < _gridSprites.GetLength(1); j++)
				{
					_gridSprites[i, j] = new Sprite();
					_gridSprites[i, j].Order = 500;
					_gridSprites[i, j].Texture = _gridTexture;
					_gridSprites[i, j].DestRect = new Rectangle(i*_gridSize + (int) Position.X, j*_gridSize + (int) Position.Y,
					                                            _gridSize, _gridSize);
				}
			}

			base.Initialize();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			// TODO: Add your update code here

			base.Update(gameTime);
		}

		public bool AddShip(uint x, uint y, uint size, bool isHorizontal)
		{
			if (x > _blocks.GetLength(0) || y > _blocks.GetLength(1)
				||(isHorizontal && x + size > _blocks.GetLength(0)) 
				||(!isHorizontal && x + size > _blocks.GetLength(1)))
			{
				return false;
			}
		}
	}
}
