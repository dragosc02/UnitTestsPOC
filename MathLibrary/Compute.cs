namespace MathLibrary
{
    public interface ICompute
    {
        /// <summary>Will sum the results for a basic operation between a and b and a complex operation between b and c.</summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The sum of the basic operation and a complex operation.</returns>
        int PerformOperations(int a, int b, int c);
    }

    public class Compute : ICompute
    {
        private readonly IOperations _operations;

        public Compute(IOperations operations)
        {
            _operations = operations;
        }

        /// <summary>Will sum the results for a basic operation between a and b and a complex operation between b and c.</summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The sum of the basic operation and a complex operation.</returns>
        public int PerformOperations(int a, int b, int c)
        {
            int result = _operations.DoBasicOperation(a, b);
            result += _operations.DoComplexOperation(b, c);

            return result;
        }
    }
}