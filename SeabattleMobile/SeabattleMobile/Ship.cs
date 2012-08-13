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
	public class Ship
	{
		public uint X { get; private set; }
		public uint Y { get; private set; }
		public uint Size { get; private set; }

		public Ship(uint x, uint y, uint size, bool isHorizontal)
		{
			IsHorizontal = isHorizontal;
			X = x;
			Y = y;
			Size = size;
		}

		List<bool> points = new List<bool>();

		public bool IsHorizontal { get; private set; }

		public bool IsBroken()
		{
			if (points.Any(point => !point))
			{
				return false;
			}
			return true;
		}
	}
}
