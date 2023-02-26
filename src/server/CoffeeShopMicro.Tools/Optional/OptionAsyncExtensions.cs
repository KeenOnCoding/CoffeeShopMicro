
using CoffeeShopMicro.Tools.Optional.Unsafe;

namespace CoffeeShopMicro.Tools.Optional
{
    public static class OptionAsyncExtensions
    {
        public static Option<T, TException> Filter<T, TException>(this Option<T, TException> option, Func<T, bool> predicate, TException exception)
        {
            return option.Match((T x) => (!predicate(x)) ? Option.None<T, TException>(exception) : option, (TException _) => option);
        }

        public static Task<Option<T>> FilterAsync<T>(this Option<T> option, Func<T, Task<bool>> predicate)
        {
            return option.MatchAsync(async (T x) => (await predicate(x)) ? option : Option.None<T>(), () => option);
        }

        public static Task<Option<T, TException>> FilterAsync<T, TException>(this Option<T, TException> option, Func<T, Task<bool>> predicate, TException exception)
        {
            return option.MatchAsync(async (T x) => (await predicate(x)) ? option : Option.None<T, TException>(exception), (TException _) => option);
        }

        public static async Task<Option<T>> FilterAsync<T>(this Task<Option<T>> optionTask, Func<T, Task<bool>> predicate)
        {
            return await (await optionTask).FilterAsync(predicate);
        }

        public static async Task<Option<T, TException>> FilterAsync<T, TException>(this Task<Option<T, TException>> optionTask, Func<T, Task<bool>> predicate, TException exception)
        {
            return await (await optionTask).FilterAsync(predicate, exception);
        }

        public static async Task<Option<T, TException>> WithException<T, TException>(this Task<Option<T>> option, TException exception)
        {
            return (await option).WithException(exception);
        }

        public static Task<Option<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Option<T, TException>> option, Func<T, Task<Option<TResult, TException>>> mapping)
        {
            return option.MatchAsync(async (T val) => await mapping(val), async (TException err) => Option.None<TResult, TException>(err));
        }

        public static Task<Option<TResult>> FlatMapAsync<T, TResult>(this Task<Option<T>> option, Func<T, Task<Option<TResult>>> mapping)
        {
            return option.MatchAsync(async (T val) => await mapping(val), async () => Option.None<TResult>());
        }

        public static async Task<Option<T, TException>> FilterAsync<T, TException>(this Task<Option<T>> optionTask, Func<T, Task<bool>> predicate, TException exception)
        {
            return await (await optionTask).FilterAsync(predicate).WithException(exception);
        }

        public static Task<Option<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Option<T, TException> option, Func<T, Task<Option<TResult, TException>>> mapping)
        {
            return option.MatchAsync(async (T val) => await mapping(val), (TException err) => Option.None<TResult, TException>(err));
        }

        public static Task<Option<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Option<T> option, Func<T, Task<Option<TResult, TException>>> mapping, TException exception)
        {
            return option.MatchAsync(async (T val) => await mapping(val), async () => Option.None<TResult, TException>(exception));
        }

        public static Task<Option<TResult>> FlatMapAsync<T, TResult>(this Option<T> option, Func<T, Task<Option<TResult>>> mapping)
        {
            return option.MatchAsync(async (T val) => await mapping(val), () => Option.None<TResult>());
        }

        public static Task<Option<TResult>> MapAsync<T, TResult>(this Task<Option<T>> option, Func<T, Task<TResult>> mapping)
        {
            return option.MatchAsync(async (T val) => (await mapping(val)).Some(), async () => Option.None<TResult>());
        }

        public static Task<Option<TResult, TException>> MapAsync<T, TException, TResult>(this Option<T, TException> option, Func<T, Task<TResult>> mapping)
        {
            return option.MatchAsync(async (T val) => (await mapping(val)).Some<TResult, TException>(), (TException err) => Option.None<TResult, TException>(err));
        }

        public static Task<Option<TResult, TException>> MapAsync<T, TException, TResult>(this Task<Option<T, TException>> option, Func<T, Task<TResult>> mapping)
        {
            return option.MatchAsync(async (T val) => (await mapping(val)).Some<TResult, TException>(), async (TException err) => Option.None<TResult, TException>(err));
        }

        public static Task<Option<TResult>> MapAsync<T, TResult>(this Option<T> option, Func<T, Task<TResult>> mapping)
        {
            return option.MatchAsync(async (T val) => (await mapping(val)).Some(), () => Option.None<TResult>());
        }

        public static Task<TResult> MatchAsync<T, TResult>(this Option<T> option, Func<T, Task<TResult>> some, Func<Task<TResult>> none)
        {
            return option.Match(some, none);
        }

        public static Task<TResult> MatchAsync<T, TException, TResult>(this Option<T, TException> option, Func<T, Task<TResult>> some, Func<TException, Task<TResult>> none)
        {
            return option.Match(some, none);
        }

        public static async Task<TResult> MatchAsync<T, TException, TResult>(this Task<Option<T, TException>> option, Func<T, Task<TResult>> some, Func<TException, Task<TResult>> none)
        {
            return await (await option).Match(some, none);
        }

        public static async Task<TResult> MatchAsync<T, TResult>(this Task<Option<T>> option, Func<T, Task<TResult>> some, Func<Task<TResult>> none)
        {
            return await (await option).Match(some, none);
        }

        public static Task<TResult> MatchAsync<T, TResult>(this Option<T> option, Func<T, Task<TResult>> some, Func<TResult> none)
        {
            return option.Match<Task<TResult>>((T x) => some(x), () => Task.FromResult(none()));
        }

        public static Task<TResult> MatchAsync<T, TException, TResult>(this Option<T, TException> option, Func<T, Task<TResult>> some, Func<TException, TResult> none)
        {
            return option.Match<Task<TResult>>((T x) => some(x), (TException e) => Task.FromResult(none(e)));
        }

        public static async Task MatchSomeAsync<T>(this Option<T> option, Func<T, Task> some)
        {
            option.MatchSome(delegate (T val)
            {
                some(val);
            });
        }

        public static async Task<Option<T, TException>> SomeNotNull<T, TException>(this Task<T> task, TException exception)
        {
            return (await task).SomeNotNull(exception);
        }

        public static async Task<Option<T>> SomeNotNull<T>(this Task<T> task)
        {
            return (await task).SomeNotNull();
        }

        public static Option<T, TException> SomeWhen<T, TException>(this T value, Func<T, bool> predicate, Func<T, TException> exceptionFactory)
        {
            if (!predicate(value))
            {
                return Option.None<T, TException>(exceptionFactory(value));
            }

            return value.Some<T, TException>();
        }

        public static async Task<Option<T, TException>> SomeWhen<T, TException>(this Task<T> valueTask, Func<T, bool> predicate, Func<T, TException> exceptionFactory)
        {
            T val = await valueTask;
            return predicate(val) ? val.Some<T, TException>() : Option.None<T, TException>(exceptionFactory(val));
        }

        public static async Task<Option<T, TException>> SomeWhen<T, TException>(this Task<T> task, Func<T, bool> predicate, TException exception)
        {
            return (await task).SomeWhen(predicate, exception);
        }

        public static async Task<Option<T, TException>> SomeWhenAsync<T, TException>(this T value, Func<T, Task<bool>> predicate, TException exception)
        {
            return (await predicate(value)) ? value.Some<T, TException>() : Option.None<T, TException>(exception);
        }

        public static async Task<Option<T, TException>> SomeWhenAsync<T, TException>(this T value, Func<T, Task<bool>> predicate, Func<T, TException> exceptionFactory)
        {
            return (await predicate(value)) ? value.Some<T, TException>() : Option.None<T, TException>(exceptionFactory(value));
        }

        public static async Task MatchAsync<T>(this Option<T> option, Func<T, Task> some, Func<Task> none)
        {
            if (option.HasValue)
            {
                await some(option.ValueOrDefault());
            }
            else
            {
                await none();
            }
        }

        public static async Task MatchAsync<T>(this Option<T> option, Func<T, Task> some, Action none)
        {
            if (option.HasValue)
            {
                await some(option.ValueOrDefault());
            }
            else
            {
                none();
            }
        }
    }
}
