namespace BolSno.Common;

public interface IFormattingStrategy
{
                string ToString(Var self);

                string DumpString(Var self);

                string DebugVar(Var self);
}