using System.Diagnostics;
using System.Reflection;
using IronXL;

namespace StudentDataRecord.StudentDataRecord.Models.Creation
{
    internal class XlsxWorkbook<T> where T : new()
    {
        private WorkBook? _xlsxWorkBook;
        public readonly List<string> ColumnNamesList;
        public readonly string PathToWorkbook;
        public readonly bool HasHeaders;

        public XlsxWorkbook(List<string>? columnNamesList, string pathToSave, bool hasHeaders)
        {
            License.LicenseKey =
                "IRONXL.SAIFISLAM.2963-167F914F30-BVTWKU7TDIR7IPH-ERAYMMDYPERI-DKT2Y7KT56HB-AMNEIVBUIFAU-4BKHF2IIRGAD-EZ4M62-T2O2AUADPPKHUA-DEPLOYMENT.TRIAL-WVYKTL.TRIAL.EXPIRES.04.OCT.2022";
            ValidateInput(columnNamesList, pathToSave);
            ColumnNamesList = columnNamesList!;
            PathToWorkbook = pathToSave;
            HasHeaders = hasHeaders;
            _xlsxWorkBook = WorkBook.Create(ExcelFileFormat.XLSX);
        }

        private static void ValidateInput(List<string>? columnNamesList, string pathToSave)
        {
            Debug.Assert(columnNamesList != null, nameof(ColumnNamesList) + " != null");
            Debug.Assert(pathToSave != "", nameof(pathToSave) + " != \"\"");
        }

        public WorkBook CreateWorkBook(string author, string mainWorkSheetName)
        {
            _xlsxWorkBook = WorkBook.Create(ExcelFileFormat.XLSX);

            _xlsxWorkBook.Metadata.Author = author;

            var xlsxWorkSheet = _xlsxWorkBook.CreateWorkSheet(mainWorkSheetName);

            if (HasHeaders)
            {
                for (var i = 0; i < ColumnNamesList.Count; i++)
                {
                    xlsxWorkSheet[$"{GetColNameFromIndex(i + 1)}1"].Value = ColumnNamesList[i];
                }
            }
            
            _xlsxWorkBook.SaveAs(PathToWorkbook);

            return _xlsxWorkBook;
        }

        public List<T> ReadWorkBook()
        {
            try
            {
                var workBook = WorkBook.Load(PathToWorkbook);
                var sheet = workBook.WorkSheets.First();
                var collection = new List<T>();
                var totalElements = HasHeaders ? 1 : 0;

                while (true)
                {
                    if (HasReachedTheEndOfRows(sheet, totalElements))
                    {
                        break;
                    }

                    dynamic instance = new T();

                    for (var i = 0; i < ColumnNamesList.Count; i++)
                    {
                        var element = sheet[$"{GetColNameFromIndex(i + 1)}{totalElements + 1}"].StringValue;

                        PropertyInfo propertyInfo = instance.GetType().GetProperty(ColumnNamesList[i]);
                        propertyInfo.SetValue(instance, Convert.ChangeType(element, propertyInfo.PropertyType),
                            null);
                    }
                    
                    collection.Add(instance);
                    totalElements += 1;
                }

                return collection;
            }
            catch (Exception exception)
            {
                if (!exception.GetType().IsInstanceOfType(new FileNotFoundException()))
                    throw new Exception($"Exception caught '{exception.Message}'");

                CreateWorkBook(@"Astera", "MainWorkSheet");
                return new List<T>();
            }
        }

        private static bool HasReachedTheEndOfRows(WorkSheet sheet, int totalElements)
        {
            return string.IsNullOrEmpty(sheet[$"A{totalElements + 1}"].StringValue);
        }

        public void WriteToSheet(List<T>? elementsList)
        {
            var sheetName = _xlsxWorkBook!.WorkSheets.Count > 0 ? _xlsxWorkBook.WorkSheets.First().Name : "DefaultSheetName";
            var authorName = _xlsxWorkBook!.Metadata.Author;

            if (File.Exists(PathToWorkbook))
            {
                File.Delete(PathToWorkbook);
            }

            _xlsxWorkBook = CreateWorkBook(authorName, sheetName);

            var xlsxWorkSheet = ExtractXlsxWorkSheet(_xlsxWorkBook);

            WriteHeaders(xlsxWorkSheet);

            var headerIncrement = HasHeaders ? 1 : 0;

            for (var i = 0 + headerIncrement; i < elementsList!.Count + headerIncrement; i++)
            {
                var element = elementsList[i - headerIncrement];
                for (var j = 0; j < ColumnNamesList.Count; j++)
                {
                    xlsxWorkSheet[$"{GetColNameFromIndex(j + 1)}{i + 1}"].Value =
                        element?.GetType().GetProperty(ColumnNamesList[j])?.GetValue(
                            element, null);
                }
            }

            SaveXlsxWorkSheet(xlsxWorkSheet);
        }

        private WorkSheet ExtractXlsxWorkSheet(WorkBook xlsxWorkBook)
        {
            return xlsxWorkBook.WorkSheets.Count == 0
                ? xlsxWorkBook.CreateWorkSheet(_xlsxWorkBook!.WorkSheets.First().Name)
                : xlsxWorkBook.WorkSheets.First();
        }

        private void SaveXlsxWorkSheet(WorkSheet xlsxWorkSheet)
        {
            xlsxWorkSheet.SaveAs(PathToWorkbook);
        }

        private void WriteHeaders(WorkSheet xlsxWorkSheet)
        {
            if (!HasHeaders) return;
            for (var i = 0; i < ColumnNamesList.Count; i++)
            {
                xlsxWorkSheet[$"{GetColNameFromIndex(i + 1)}1"].Value = ColumnNamesList[i];
            }
        }
        
        private static string GetColNameFromIndex(int columnNumber)
        {
            // // (1 = A, 2 = B...27 = AA...703 = AAA...)
            var dividend = columnNumber;
            var columnName = string.Empty;

            while (dividend > 0)
            {
                var modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }
    }
}

