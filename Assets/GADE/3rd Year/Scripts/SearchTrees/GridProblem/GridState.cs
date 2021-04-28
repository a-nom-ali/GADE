using UnityEngine;

namespace GridProblem
{

	public class GridState : State
	{

		private bool wall = false;
		public int i, j;

		public GridState(int x, int y)
		{
			i = x;
			j = y;
		}

		public void setWall()
		{
			wall = true;
		}

		public void clearWall()
		{
			wall = false;
		}

		public bool isWall()
		{
			return wall;
		}

		public bool equals(GridState s)
		{
			return (i == s.i && j == s.j);
		}

		public void print()
		{
			Debug.Log(i + " " + j);
		}
	}
}