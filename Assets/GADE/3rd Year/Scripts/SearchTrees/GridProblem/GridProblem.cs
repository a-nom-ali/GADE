using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace GridProblem
{

	public class GridProblem : IProblem
	{

		GridState[,] grid;
		int n;
		int m;
		int[,] c;

		GridState startState;
		GridState goalState;

		static GridOperator UP = new GridOperator("up", 1, 0);
		static GridOperator DOWN = new GridOperator("down", -1, 0);
		static GridOperator LEFT = new GridOperator("left", 0, -1);
		static GridOperator RIGHT = new GridOperator("right", 0, 1);

		GridOperator[] ops = {UP, DOWN, LEFT, RIGHT};

		private Random dice = new Random();

		public GridProblem(int nn, int mm, int MaxCostRange, double p)
		{

			if (nn < 3 || mm < 3)
				throw new Exception("Grid has to be at least 3 in each dimension");

			if (MaxCostRange <= 0)
				throw new Exception("Costs have to be strictly positive");

			n = nn;
			m = mm;

			// initialize the grid
			grid = new GridState[n,m];

			// initialize cost array
			c = new int[n,m];

			//make the states
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					grid[i,j] = new GridState(i, j);

					// add some walls and costs
					if (dice.NextDouble() < p)
						grid[i,j].setWall();

					c[i,j] = 1 + Mathf.Abs(dice.Next()) % MaxCostRange;
				}
			}

			// make a border of walls around the maze
			for (int i = 0; i < n; i++)
			{
				grid[i,0].setWall();
				grid[i,m - 1].setWall();
			}

			for (int j = 0; j < m; j++)
			{
				grid[0,j].setWall();
				grid[n - 1,j].setWall();
			}

			//set the start state
			startState = grid[1,1];
			startState.clearWall();

			// set a goal state
			goalState = grid[n - 2,m - 2];
			goalState.clearWall();
		}

		public State getStartState()
		{
			return startState;
		}

		// return next state
		public State nextState(State crtState, Operator op)
		{

			int i = ((GridState) crtState).i + ((GridOperator) op).delta_i;
			int j = ((GridState) crtState).j + ((GridOperator) op).delta_j;
			return (grid[i,j].isWall()) ? crtState : grid[i,j];
		}

		// goal test
		public bool isGoal(State crtState)
		{
			return goalState.equals((GridState) crtState);
		}

		// start test
		public bool isStart(State crtState)
		{
			return startState.equals((GridState) crtState);
		}

		public int cost(State crtState, Operator op)
		{

			int i = ((GridState) crtState).i + ((GridOperator) op).delta_i;
			int j = ((GridState) crtState).j + ((GridOperator) op).delta_j;
			return (grid[i,j].isWall()) ? c[((GridState) crtState).i,((GridState) crtState).j] : c[i,j];
		}

		// All operators are legal in all states
		public bool isLegal(State crtState, Operator op)
		{
			return true;
		}

		//Get legal operators in an ArrayList
		//Note that since all operators are legal at all states, this always returns all operators 
		public List<Operator> getLegalOps(State crtState)
		{

			List<Operator> result = new List<Operator>(4);
			for (int i = 0; i < 4; i++)
			{
				result.Add(ops[i]);
			}

			return result;
		}

		public void print()
		{
			var s = "";
			for (int i = 1; i <= n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (isGoal(grid[n - i,j]))
						s += (" G ");
					else if (isStart(grid[n - i,j]))
						s += (" S ");
					else if (grid[n - i,j].isWall())
						s += (" W ");
					else s += (" " + c[n - i,j] + " ");
				}

				s += "\n";
			}
			Debug.Log(s);
		}
	}
}