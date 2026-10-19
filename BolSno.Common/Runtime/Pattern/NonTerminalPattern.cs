namespace BolSno.Common;

internal abstract class NonTerminalPattern : Pattern
{
                                                                internal override bool IsTerminal()
    {
        return false;
    }
}