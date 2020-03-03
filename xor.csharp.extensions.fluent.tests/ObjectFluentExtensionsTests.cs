using FluentAssertions;
using System;
using Xunit;

namespace xor.csharp.extensions.fluent.tests
{
    public class ObjectFluentExtensionsTests
    {
        [Fact]
        public void GivenAnObject_FluentAdapter_ShouldReturnSameReference()
        {
            var expected = new object();

            var actual = expected.FluentAdapter(() => { });

            actual.Should().BeSameAs(expected);
        }

        [Fact]
        public void GivenANullAction_FluentAdapter_ShouldThrowAnException()
        {
            var subject = new object();

            Action action = () => subject.FluentAdapter(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GivenANullReference_FluentAdapter_ShouldThrowAnException()
        {
            Action action = () => ObjectFluentExtensions.FluentAdapter<object>(null, () => { });

            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenAnObject_If_ShouldReturnSameReference(bool predicate)
        {
            var expected = new object();

            var actual = expected.If(predicate, o => o);

            actual.Should().BeSameAs(expected);
        }

        [Fact]
        public void GivenAFalsePredicate_If_ShouldReturnSameReference()
        {
            var expected = new object();

            var actual = expected.If(false, o => o);

            actual.Should().BeSameAs(expected);
        }

        [Fact]
        public void GivenATruePredicate_If_ShouldReturnActionValue()
        {
            var subeject = new object();
            var expected = new object();

            var actual = subeject.If(true, o => expected);

            actual.Should().BeSameAs(expected);
        }

        [Fact]
        public void GivenANullReference_If_ShouldThrowAnException()
        {
            Action action = () => ObjectFluentExtensions.If<object>(null, true, o => o);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GivenANullReferenceFunc_If_ShouldThrowAnException()
        {
            var subject = new object();

            Action action = () => subject.If(true, null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GivenANullReferencePredicateAction_If_ShouldThrowAnException()
        {
            var subject = new object();

            Action action = () => subject.If((Func<bool>)null, o => o);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GivenANullReferencePredicateFunc_If_ShouldThrowAnException()
        {
            var subject = new object();

            Action action = () => subject.If((Func<object, bool>)null, o => o);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
