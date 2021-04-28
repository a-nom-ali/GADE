using UnityEngine;

namespace GridProblem
{

	public class GridOperator : Operator
	{

		public int delta_i, delta_j;
		public string name;

		public GridOperator(string s, int x, int y)
		{
			name = s;
			delta_i = x;
			delta_j = y;
		}

		public void print()
		{
			Debug.Log(name);
		}
	}
}