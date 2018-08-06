using System;
using Xunit;

namespace CoinConversion.Domain.Tests._Utils
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException ex, string msg)
        {
            if (ex.Message.Contains(msg))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{msg}'");
        }
    }
}
