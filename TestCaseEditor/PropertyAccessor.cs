using System;

namespace TestCaseEditor
{
    public class PropertyAccessor<T>
    {
        private readonly Func<T> _getFunc;
        private readonly Action<T> _setFunc;

        public PropertyAccessor(Func<T> getFunc, Action<T> setFunc)
        {
            _getFunc = getFunc;
            _setFunc = setFunc;
        }

        public T Get()
        {
            return (_getFunc());
        }

        public void Set(T value)
        {
            _setFunc(value);
        }
    }
}
