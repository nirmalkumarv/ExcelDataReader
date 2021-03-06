using System;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace ExcelDataReader.Tests
{
    [TestClass]
    public class ExcelReaderFactoryTests
    {
        [TestMethod]
        public void ProbeXLS()
        {
            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(Configuration.GetTestWorkbook("Test10x10")))
            {
                Assert.AreEqual(excelReader.GetType().Name, "ExcelBinaryReader");
            }

            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(Configuration.GetTestWorkbook("TestUnicodeChars")))
            {
                Assert.AreEqual(excelReader.GetType().Name, "ExcelBinaryReader");
            }

            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(Configuration.GetTestWorkbook("biff3")))
            {
                Assert.AreEqual(excelReader.GetType().Name, "ExcelBinaryReader");
            }

            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(Configuration.GetTestWorkbook("as3xls_BIFF2")))
            {
                Assert.AreEqual(excelReader.GetType().Name, "ExcelBinaryReader");
            }
        }

        [TestMethod]
        public void ProbeXLSX()
        {
            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(Configuration.GetTestWorkbook("xTest10x10")))
            {
                Assert.AreEqual(excelReader.GetType().Name, "ExcelOpenXmlReader");
            }

            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(Configuration.GetTestWorkbook("xTestOpenXml")))
            {
                Assert.AreEqual(excelReader.GetType().Name, "ExcelOpenXmlReader");
            }
        }
    }
}
