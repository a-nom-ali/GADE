using System;
using System.Collections.Generic;
using GridProblem;
using UnityEngine;

public class TestGrid : MonoBehaviour
{

	public void Start()
	{

		try
		{
			GridProblem.GridProblem g = new GridProblem.GridProblem(7, 7, 4, 0.2);
			Debug.Log("Example of random grid:");
			g.print();

			Debug.Log("Start state:");
			State start = g.getStartState();
			start.print();

			List<Operator> a = g.getLegalOps(start);
			for (int i = 0; i < a.Count; i++)
			{
				// get an operator
				Operator op = a[i];
				op.print();
				State s = g.nextState(start, op);
				Debug.Log("Next state:");
				s.print();
				Debug.Log("Cost: " + g.cost(start, op));
			}
		}
		catch (Exception e)
		{
			Debug.LogError(e);
		}
	}
}