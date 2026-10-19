namespace BolSno.Common;

public class StringCloningStrategy : ICloningStrategy
{
    public Var Clone(Var self)
    {
        var stringSelf = (StringVar)self;
        return new StringVar(stringSelf);
    }
}