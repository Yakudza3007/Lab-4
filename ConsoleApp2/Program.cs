public class A
{
    public int _x;
    public int _y;

    public A(int x, int y)
    {
        this._x = x;
        this._y = y;
    }

    public override string ToString()
    {
        return "x = " + _x + ", y = " + _y;
    }
    
    // перегрузка унарных операций

    public static A operator --(A a)
    {
        return new A(--a._x, --a._y);
    }
}