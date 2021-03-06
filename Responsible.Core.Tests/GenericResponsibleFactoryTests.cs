﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Responsible.Core.Tests
{
    [TestClass]
    public class GenericResponsibleFactoryTests
    {
        [TestMethod]
        public void Response_OK()
        {
            var okResponse = ResponseFactory<int>.Ok(5);

            Assert.IsNotNull(okResponse, "Response is null");
            Assert.IsTrue(okResponse.Success, "Success is not true.");
            Assert.AreEqual(ResponseStatus.Ok, okResponse.Status, "Status is not valid");
            Assert.AreEqual(5, okResponse.Value, "Values are not equal");
        }

        [TestMethod]
        public void Response_Error()
        {
            var errorResponse = ResponseFactory<int>.Error(nameof(Response_Error));

            Assert.IsNotNull(errorResponse, "Response is null");
            Assert.IsFalse(errorResponse.Success, "Success is not false.");
            Assert.AreEqual(ResponseStatus.InternalServerError, errorResponse.Status, "Status is not valid");
            Assert.AreEqual(0, errorResponse.Value, "Values are not equal");
            Assert.IsNotNull(errorResponse.Messages, "Message list is null");
            Assert.AreEqual(1, errorResponse.Messages.Count(), "Message count is not as expected");
            Assert.AreEqual(nameof(Response_Error), errorResponse.Messages.ToList()[0], "Invalid message");
        }

        [TestMethod]
        public void Response_Error_ExpectedOutput_Should_Be_NULL()
        {
            var errorResponse = ResponseFactory<int?>.Error(nameof(Response_Error));

            Assert.IsNotNull(errorResponse, "Response is null");
            Assert.IsFalse(errorResponse.Success, "Success is not false.");
            Assert.AreEqual(ResponseStatus.InternalServerError, errorResponse.Status, "Status is not valid");
            Assert.AreEqual(null, errorResponse.Value, "Values are not equal");
            Assert.IsNotNull(errorResponse.Messages, "Message list is null");
            Assert.AreEqual(1, errorResponse.Messages.Count(), "Message count is not as expected");
            Assert.AreEqual(nameof(Response_Error), errorResponse.Messages.ToList()[0], "Invalid message");
        }

        [TestMethod]
        public void Response_Error_Converted_Response_Should_Be_Same_With_Value()
        {
            var errorResponse = ResponseFactory<int>.Ok(55);
            var convertedResponse = ResponseFactory<int>.Convert(errorResponse);

            Assert.AreEqual(errorResponse.Status, convertedResponse.Status, "Status is not same");
            Assert.AreEqual(errorResponse.Success, convertedResponse.Success, "Success is not same");
            Assert.AreEqual(errorResponse.Exception, convertedResponse.Exception, "Exceptionsd are not same");
            Assert.AreEqual(errorResponse.Value, convertedResponse.Value, "Values are not same");
        }

        [TestMethod]
        public void Response_Error_Convert()
        {
            var errorResponse = ResponseFactory<string>.Convert(null);

            Assert.IsFalse(errorResponse.Success);
            Assert.AreEqual(ResponseStatus.NotFound, errorResponse.Status);
        }

        [TestMethod]
        public void Response_Error_SetsEmptyList()
        {
            var errorResponse = ResponseFactory<List<int>>.Error();

            Assert.IsFalse(errorResponse.Success);
            Assert.IsNotNull(errorResponse.Value, "Value is null");
            Assert.AreEqual(0, errorResponse.Value.Count, "List count is not same");
        }

        [TestMethod]
        public void Response_Error_CannotSetsEmptyList_IEnumrable()
        {
            var errorResponse = ResponseFactory<IEnumerable<int>>.Error();

            Assert.IsFalse(errorResponse.Success);
            Assert.IsNull(errorResponse.Value, "Value is not null");
        }
    }
}