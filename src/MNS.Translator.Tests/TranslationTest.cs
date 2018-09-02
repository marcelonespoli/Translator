using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MNS.Translator.Domain.Models;

namespace MNS.Translator.Tests
{
    [TestClass]
    public class TranslationTest
    {
        [TestMethod]
        public void Translation_Is_Valid()
        {
            // Arrange
            var translation = new TranslationRequest
            {
                Text = "Leet Speak",
                Success = true,
                Translation = "LE3T SPE@c",
                Date = DateTime.Now
            };

            // Act
            var result = translation.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Translation_Not_Valid()
        {
            // Arrange
            var translation = new TranslationRequest
            {
                Text = "",
                Success = true,
                Translation = ""
            };

            // Act
            var result = translation.IsValid();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
