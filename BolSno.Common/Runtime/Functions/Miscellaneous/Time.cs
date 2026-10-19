namespace BolSno.Common;

public partial class Executive
{
    internal void Time(List<Var> arguments)
    {
        SystemStack.Push(new IntegerVar(_timerExecute.ElapsedMilliseconds));
    }
}