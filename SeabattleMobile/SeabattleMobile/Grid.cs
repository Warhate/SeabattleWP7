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
		const uint ONE_SHIP_COUNT = 4;
		const uint TWO_SHIP_COUNT = 3;
		const uint THREE_SHIP_COUNT = 2;
		const uint FOUR_SHIP_COUNT = 1;

		int GRID_SIZE = 10;

		Texture2D _gridTexture;
		Texture2D _shipTexture;
		Texture2D _missTexture;
		Texture2D _waterTexture;

		int _gridSize = 40;

		public Vector2 Position { get; set; }

		Sprite[,] _gridSprites;
		Sprite[,] _stateSprites;
		bool[,] _shots;
		bool[,] _blocks;

		List<Ship> _ships = new List<Ship>(); 

		public Grid(Game game)
			: base(game)
		{
			_blocks = new bool[GRID_SIZE, GRID_SIZE];
			_gridSprites = new Sprite[GRID_SIZE,GRID_SIZE];
			_stateSprites = new Sprite[GRID_SIZE,GRID_SIZE];
			Position = new Vector2(50,50);
		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			_gridTexture = Game.Content.Load<Texture2D>("grid");
			_waterTexture = Game.Content.Load<Texture2D>("water");

			for (int i = 0; i < _gridSprites.GetLength(0); i++)
			{
				for (int j = 0; j < _gridSprites.GetLength(1); j++)
				{
					_stateSprites[i,j] = new Sprite();
					_stateSprites[i, j].Order = 2;
					_stateSprites[i, j].Texture = _waterTexture;
					_stateSprites[i, j].DestRect = new Rectangle(i * _gridSize + (int)Position.X, j * _gridSize + (int)Position.Y,
																_gridSize, _gridSize);
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

		public bool isLose()
		{
			for (int i = 0; i < _gridSprites.GetLength(0); i++)
			{
				for (int j = 0; j < _gridSprites.GetLength(1); j++)
				{
					if(_blocks[i,j] && !_blocks[i,j])
					{
						return false;
					}
				}
			}

			return true;
		}

		public bool Shot(uint x, uint y)
		{
			if (_shots[x, y] ||  x > _blocks.GetLength(0) || y > _blocks.GetLength(1))
			{
				return false;
			}

			_shots[x, y] = true;

			return true;
		}

		public bool AllShipPlaced()
		{
			if(_ships.Count == (ONE_SHIP_COUNT + TWO_SHIP_COUNT + THREE_SHIP_COUNT + FOUR_SHIP_COUNT))
			{
				return true;
			}

			return false;
		}

		public bool AddShip(uint x, uint y, uint size, bool isHorizontal)
		{
			if (!ValidPosition(x, y, size, isHorizontal) || !ValidShipCount(size))
			{
				return false;
			}

			for (uint i = isHorizontal?x:y; i < size; i++)
			{
				if(isHorizontal)
				{
					_blocks[i, y] = true;
				}
				else
				{
					_blocks[x, i] = true;
				}
			}

			_ships.Add(new Ship(x,y,size,isHorizontal));

			return true;
		}

		bool ValidShipCount(uint size)
		{
			switch (size)
			{
				case (1):
				{
					if (ONE_SHIP_COUNT <= _ships.Count(e => e.Size == size))
					{
						return true;
					}
					
					return false;
				}
				case (2):
				{
					if (TWO_SHIP_COUNT <= _ships.Count(e => e.Size == size))
					{
						return true;
					}

					return false;
				}
				case (3):
				{
					if (THREE_SHIP_COUNT <= _ships.Count(e => e.Size == size))
					{
						return true;
					}

					return false;
				}
				case (4):
				{
					if (FOUR_SHIP_COUNT <= _ships.Count(e => e.Size == size))
					{
						return true;
					}

					return false;
				}
				default:
				{
					return false;
				}
			}
		}

		bool ValidPosition(uint x, uint y, uint size, bool isHorizontal)
		{
			if (x > _blocks.GetLength(0) || y > _blocks.GetLength(1)
			    || (isHorizontal && x + size > _blocks.GetLength(0))
			    || (!isHorizontal && x + size > _blocks.GetLength(1)))
			{
				return false;
			}

			//if blocks free
			for (uint i = x - 1; i <= x + 1; i++)
			{
				for (uint j = y - 1; j <= y + 1; j++)
				{
					if (j == 1 && i == 1)
					{
						continue;
					}

					if (_blocks[i, j])
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
