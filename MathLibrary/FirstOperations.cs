namespace MathLibrary
{
    public class FirstOperations : IOperations
    {
        private readonly int c_factor = 2;

        public int DoBasicOperation(int a, int b)
        {
            return c_factor + a - b;
        }

        public int DoComplexOperation(int a, int b)
        {
            return c_factor * (b - a);
        }
    }
}
