using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class Solution154
    {
        public class Stack<T>:IEnumerable<T>
        {
            public Stack()
            {

            }

            public Stack(IEnumerable<int> input)
            {
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new System.NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}