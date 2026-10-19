namespace BolSno.Common;

internal class CompilerTargets
{
    internal string FileName;
    internal string ClassName;
    internal string NameSpace;
    internal string FullClassName;
    internal int CodeNum;
    internal int EvalNum;

    internal CompilerTargets()
    {
        FileName = "";
        ClassName = "";
        NameSpace = "";
        FullClassName = "";
        CodeNum = 0;
        EvalNum = 0;
    }
}