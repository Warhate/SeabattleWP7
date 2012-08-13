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
		List<bool> points = new List<bool>();

		public bool IsHorizontal = false;
		
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
