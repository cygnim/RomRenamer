﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomRenamer.ConsoleApp;
using RomRenamer.Tests.Stubs;

namespace RomRenamer.Tests
{
    [TestClass]
    public class DirectoryFinderTests
    {
        [TestMethod]
        public void Find_ReturnsTwoFiles_PassedValidPath()
        {
            var readKeys = new List<char> {};
            var readLines = new List<string> {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestRoms"};

            var testUserInteraction = new TestUserReadWrite(readKeys, readLines);

            var directoryFinder = new DirectoryFinder(testUserInteraction);
            var files = directoryFinder.Find();
            Assert.AreEqual(2, files.Count);
        }

        [TestMethod]
        public void Find_ReturnsNull_PassedInvalidPath()
        {
            var readKeys = new List<char> { 'n' };
            var readLines = new List<string> { @"E:\derpytestest" };

            var testUserInteraction = new TestUserReadWrite(readKeys, readLines);

            var directoryFinder = new DirectoryFinder(testUserInteraction);
            var files = directoryFinder.Find();
            Assert.IsNull(files);
        }

        [TestMethod]
        public void Find_ReturnsTwoFiles_FirsPathInvalidSecondValid()
        {
            var readKeys = new List<char> { 'y', 'n' };
            var readLines = new List<string> { @"E:\derpytestest", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestRoms" };

            var testUserInteraction = new TestUserReadWrite(readKeys, readLines);

            var directoryFinder = new DirectoryFinder(testUserInteraction);
            var files = directoryFinder.Find();
            Assert.AreEqual(2, files.Count);
        }
    }
}
