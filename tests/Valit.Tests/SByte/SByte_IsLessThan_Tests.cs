using Shouldly;
using Xunit;

namespace Valit.Tests.SByte
{
    public class SByte_IsLessThan_Tests
    {

        [Fact]
        public void SByte_IsLessThan_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, sbyte>)null)
                    .IsLessThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void SByte_IsLessThan_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, sbyte>)null)
                    .IsLessThan((sbyte?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void SByte_IsLessThan_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, sbyte?>)null)
                    .IsLessThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void SByte_IsLessThan_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, sbyte?>)null)
                    .IsLessThan((sbyte?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(11, true)]
        [InlineData(10, false)]
        [InlineData(9, false)]
        public void SByte_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Values(sbyte value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData((sbyte) 11, true)]
        [InlineData((sbyte) 10, false)]
        [InlineData((sbyte) 9, false)]
        [InlineData(null, false)]
        public void SByte_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(sbyte? value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, 11, true)]
        [InlineData(false, 10, false)]
        [InlineData(false, 9, false)]
        [InlineData(true, 11, false)]
        public void SByte_IsLessThan_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, sbyte value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, (sbyte) 11, true)]
        [InlineData(false, (sbyte) 10, false)]
        [InlineData(false, (sbyte) 9, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (sbyte) 11, false)]
        [InlineData(true, null, false)]
        public void SByte_IsLessThan_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, sbyte? value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public SByte_IsLessThan_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public sbyte Value => 10;
            public sbyte? NullableValue => 10;
            public sbyte? NullValue => null;
        }
#endregion
    }

}
