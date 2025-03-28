using EShop.Application;
using EShop.Domain.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace EShopApplication.Tests
{
    public class CreditCardServiceTest
    {
        [Theory]
        [InlineData ("3497 7965 8312 797")]
        [InlineData ("345-470-784-783-010")]
        [InlineData ("378523393817437")]
        [InlineData ("4024-0071-6540-1778")]
        [InlineData ("4532 2080 2150 4434")]
        [InlineData ("4532289052809181")]
        [InlineData ("5530016454538418")]
        [InlineData ("5551561443896215")]
        [InlineData ("5131208517986691")]
        public void ValidateCard_CorrectLenght_ExpectedTrue(string Number)
        {
            var creditCardService = new CreditCardService();

            var result = creditCardService.ValidateCard(Number);

            bool expected = true;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3497 7965 8312 79729876")]
        [InlineData("44-  0071-6540-17780 98898432 3242")]
        public void ValidateCard_CorrectLenght_ExpectedCardNumberTooLongException(string Number)
        {
            var creditCardService = new CreditCardService();


            Assert.Throws<CardNumberTooLongException>(() => creditCardService.ValidateCard(Number));
        }


        [Theory]
        [InlineData("345-470")]
        [InlineData("378523393817")]
        [InlineData("")]
        public void ValidateCard_CorrectLenght_ExpectedCardNumberTooShortException(string Number)
        {
            var creditCardService = new CreditCardService();

            Assert.Throws<CardNumberTooShortException>(() => creditCardService.ValidateCard(Number));
        }

        [Theory]
        [InlineData("American Express", "3497 7965 8312 797")]
        [InlineData("American Express", "345-470-784-783-010")]
        [InlineData("American Express", "378523393817437")]
        [InlineData("Visa", "4024-0071-6540-1778")]
        [InlineData("Visa", "4532 2080 2150 4434")]
        [InlineData("Visa", "4532289052809181")]
        [InlineData("MasterCard", "5530016454538418")]
        [InlineData("MasterCard", "5551561443896215")]
        [InlineData("MasterCard", "5131208517986691")]

        public void GetCardType_CorrectBankName_ExpectedTrue(string expected, string number)
        {
            var creditCardService = new CreditCardService();

            var result = creditCardService.GetCardType(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3589297434675026")]

        public void GetCardType_CorrectBankName_ExpectedCardNumberInvalidException(string number)
        {
            var creditCardService = new CreditCardService();

            Assert.Throws<CardNumberInvalidException>(() => creditCardService.GetCardType(number));
        }

    }
}