namespace T1
{
    public interface IBalance<T>
    {
        void SetBalance(T balance);
        T GetBalance();
    }
}
