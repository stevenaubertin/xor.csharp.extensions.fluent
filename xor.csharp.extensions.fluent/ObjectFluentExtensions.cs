using System;

namespace xor.csharp.extensions.fluent
{
    public static partial class ObjectFluentExtensions
    {
        public static T FluentAdapter<T>(this T @this, Action action)
            where T : class
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (action == null) throw new ArgumentNullException(nameof(action));

            action();
            return @this;
        }

        public static T If<T>(this T @this, bool predicate, Func<T, T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (action == null) throw new ArgumentNullException(nameof(action));

            return predicate ? action(@this) : @this;
        }

        public static T If<T>(this T @this, Func<bool> predicate, Func<T, T> action)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return If(@this, predicate(), action);
        }

        public static T If<T>(this T @this, Func<T, bool> predicate, Func<T, T> action)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return If(@this, predicate(@this), action);
        }
    }
}
