namespace GameBoard
{
    public interface IPrototype<out T>
    {
        T Clone();
    }
}
