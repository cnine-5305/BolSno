namespace BolSno.Common;

public class ExternalCloningStrategy : ICloningStrategy
{
    public Var Clone(Var self) => new ExternalVar(((ExternalVar)self).Pointer);
}
