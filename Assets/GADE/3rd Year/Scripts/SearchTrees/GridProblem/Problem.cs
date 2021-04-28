using System.Collections.Generic;

namespace GridProblem
{


    public interface IProblem
    {
        bool isLegal(State s, Operator op);
        List<Operator> getLegalOps(State s);
        State nextState(State s, Operator op);
        int cost(State s, Operator op);
        State getStartState();
        bool isStart(State s);
        bool isGoal(State s);
    }
}