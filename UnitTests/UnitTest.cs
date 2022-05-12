using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransUnion;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ShouldConvertCelsiusToKelvin()
        {
            double celsius = 100;
            double expected = 373.15;

            double result = new Temperature("Celsius") { Value = celsius }.ConvertToKelvin();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldConvertKelvinToCelsius()
        {
            double expected = 100;
            double kelvin = 373.15;

            double result = new Temperature("Kelvin") { Value = kelvin }.ConvertToCelsius();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldConvertCelsiusToFahrenheit()
        {
            double celsius = 100;
            double expected = 212;

            double result = new Temperature("Celsius") { Value = celsius }.ConvertToFahrenheit();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldConvertFahrenheitToCelsius()
        {
            double fahrenheit = 212;
            double expected = 100;

            double result = new Temperature("Fahrenheit") { Value = fahrenheit }.ConvertToCelsius();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldConvertCustomTemperatureToCelsius()
        {
            double custom = 100;
            double expected = 420;

            double result = new Temperature("CustomTemperatureTest") { Value = custom, FormulaToC = "CUSTOM * 4 + 20", FormulaFromC = "(C - 20) / 4"}.ConvertToCelsius();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldConvertCelsiusToCustomTemperature()
        {
            double celsius = 420;
            double expected = 100;

            Temperature custom = new Temperature("CustomTemperatureTest") { FormulaToC = "CUSTOM * 4 + 20", FormulaFromC = "(C - 20) / 4" };
            Temperature celsiusTemp = new Temperature("Celsius") { Value = celsius};
            double result = Temperature.CallMethodByTemperature(celsiusTemp, custom);

            Assert.AreEqual(expected, result);
        }


    }
}