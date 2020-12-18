using LumenWorks.Framework.IO.Csv;
using Macrobo.Models.Enums;
using Newtonsoft.Json;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Macrobo.Models
{
    /// <summary>
    /// Author : M.Yoshida
    /// 変数配列モデルクラス
    /// </summary>
    [Serializable]
    public class ArrayVariableModel
    {
        /// <summary>
        /// 変数配列を保持する
        /// </summary>
        public string[][] Value;
        [JsonIgnore]
        public List<List<string>> ValueList;
        /// <summary>
        /// 変数配列内容の説明を格納
        /// </summary>
        public string Description;
        /// <summary>
        /// 変数配列の列数を格納
        /// </summary>
        public int ColumnCount;
        /// <summary>
        /// Constructor
        /// </summary>
        public ArrayVariableModel()
        {
            Description = "";
            ColumnCount = 100;
            ValueList = new List<List<string>>();
            
        }
        /// <summary>
        /// デリミッターを取得する
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private char GetDelimitter(ProcessModel proc)
        {

            try
            {
                switch (proc.ArraySeparateType)
                {
                    case ArraySeparateType.CSV:
                        return ',';
                    case ArraySeparateType.TEXT:
                        return '\t';
                }
                return ',';
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 文字列から変数にセットする
        /// </summary>
        /// <param name="value"></param>
        public void SetValueFromString(string value, ProcessModel proc, bool append)
        {
            try
            {
                using (CsvReader reader = new CsvReader(new StringReader(value), false, GetDelimitter(proc)))
                {
                    if (append)
                    {
                        ValueList = ValueList.Concat(GetResultFromCsvReader(reader)).ToList();
                    }
                    else
                    {
                        ValueList = GetResultFromCsvReader(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ファイルから変数にセットする
        /// </summary>
        /// <param name="filePath"></param>
        public void SetValueFromFile(string filePath, ProcessModel proc, bool append)
        {
            try
            {
                using(CsvReader reader = new CsvReader(new StreamReader(filePath, GetEncode(proc.EncodeType)), false, GetDelimitter(proc)))
                {
                    if (append)
                    {
                        ValueList = ValueList.Concat(GetResultFromCsvReader(reader)).ToList();
                    }
                    else
                    {
                        ValueList = GetResultFromCsvReader(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CsvReaderから変数配列へセットする
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private List<List<string>> GetResultFromCsvReader(CsvReader reader)
        {
            try
            {
                List<List<string>> result = new List<List<string>>();
                int fieldCount = reader.FieldCount;
                if(fieldCount > ColumnCount)
                {
                    ColumnCount = fieldCount;
                }
                while (reader.ReadNextRecord())
                {
                    List<string> colList = new List<string>();
                    for(int i = 0; i < fieldCount; i++)
                    {

                        try
                        {
                            colList.Add(reader[i]);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    result.Add(colList);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 要素にファイルからセットする
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="filePath"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="append"></param>
        internal void SetElementFromFile(ProcessModel proc, string filePath, int rowIndex, int columnIndex, bool append)
        {
            try
            {
                using (var reader = new StreamReader(filePath, GetEncode(proc.EncodeType)))
                {
                    string text = reader.ReadToEnd();
                    if (append)
                    {
                        ValueList[rowIndex][columnIndex] = text;
                    }
                    else
                    {
                        ValueList[rowIndex][columnIndex] += text;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// エンコードクラスを取得する
        /// </summary>
        /// <returns></returns>
        public Encoding GetEncode(EncodeType encodeType)
        {
            try
            {
                switch (encodeType)
                {
                    case EncodeType.SHIFT_JIS:
                        return Encoding.GetEncoding("shift_jis");
                    case EncodeType.EUC_JP:
                        return Encoding.GetEncoding("euc_jp");
                    case EncodeType.UTF8:
                        return Encoding.UTF8;
                    default:
                        return Encoding.Default;

                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 要素に値をセットする
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="append"></param>
        internal void SetElementFromString(string value, int rowIndex, int columnIndex, bool append)
        {
            try
            {
                if (append)
                {
                    ValueList[rowIndex][columnIndex] += value;
                }
                else
                {

                    ValueList[rowIndex][columnIndex] = value;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Excelファイルに変数の値をセットする
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        internal void SetValueFromExcelFile(string filePath, string sheetName)
        {
            IWorkbook workbook = null;
            try
            {
                string ext = System.IO.Path.GetExtension(filePath).ToUpper();
                workbook = WorkbookFactory.Create(filePath);
                ISheet sheet = workbook.GetSheet(sheetName);
                int lastRow = sheet.LastRowNum;
                int lastCol = 0;

                for (int i = 0; i <= lastRow; i++)
                {
                    IRow row = sheet.GetRow(i);
                    int l = row.LastCellNum;
                    if (lastCol < l)
                    {
                        lastCol = l;
                    }
                }

                if (lastCol > ColumnCount)
                {
                    ColumnCount = lastCol;
                }
                ValueList = new List<List<string>>();
                for (int i = 0; i <= lastRow; i++)
                {
                    IRow row = sheet.GetRow(i);
                    int last = row.LastCellNum;
                    ValueList.Add(GetNewStringList("", lastCol));
                    for (int i2 = 0; i2 < lastCol; i2++)
                    {
                        ValueList[i][i2] = "";
                        if (last > i2)
                        {
                            ICell cell = row?.GetCell(i2);
                            if(cell != null)
                            {
                                switch (cell.CellType)
                                {
                                    case CellType.Blank:
                                    case CellType.Error:
                                    case CellType.Formula:
                                    case CellType.Unknown:
                                        ValueList[i][i2] = "";
                                        break;
                                    case CellType.Boolean:
                                        ValueList[i][i2] = "" + cell.BooleanCellValue.ToString();
                                        break;
                                    case CellType.String:
                                        ValueList[i][i2] = "" + cell.StringCellValue;
                                        break;
                                    case CellType.Numeric:
                                        ValueList[i][i2] = "" + cell.NumericCellValue;
                                        break;
                                }
                            }
                        }

                    }
                }
                workbook.Close();
            }
            catch (Exception ex)
            {
                if (workbook != null)
                {
                    workbook.Close();
                }
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// Excelを出力する
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        /// <param name="fileOutputType"></param>
        internal void CreateExcel(string filePath, string sheetName, FileOutputType fileOutputType)
        {
            try
            {
                IWorkbook workbook = null;
                ISheet sheet = null;
                string ext = System.IO.Path.GetExtension(filePath);
                switch (fileOutputType)
                {
                    case FileOutputType.追記:
                        if (System.IO.File.Exists(filePath))
                        {
                            using(var fs = File.OpenRead(filePath))
                            {
                                workbook = WorkbookFactory.Create(fs);
                            }
                            sheet = workbook.GetSheet(sheetName);
                        }
                        else
                        {
                            if(ext.ToUpper() == ".xls")
                            {
                                workbook = new HSSFWorkbook();
                                sheet = workbook.CreateSheet(sheetName);
                            }
                            else
                            {
                                workbook = new XSSFWorkbook();
                                sheet = workbook.CreateSheet(sheetName);
                            }
                        }
                        
                        break;
                    case FileOutputType.上書き:
                        if (ext.ToUpper() == ".xls")
                        {
                            workbook = new HSSFWorkbook();
                            sheet = workbook.CreateSheet(sheetName);
                        }
                        else
                        {
                            workbook = new XSSFWorkbook();
                            sheet = workbook.CreateSheet(sheetName);
                        }
                        break;
                }

                switch (fileOutputType)
                {
                    case FileOutputType.追記:
                        {
                            int last = sheet.LastRowNum;
                            if(last > 0)
                            {
                                last++;
                            }
                            for (int r = 0; r < ValueList.Count; r++)
                            {
                                IRow row = sheet.CreateRow(r + last);
                                for (int c = 0; c < ValueList[r].Count; c++)
                                {
                                    ICell cell = row.CreateCell(c);
                                    cell.SetCellValue(ValueList[r][c]);
                                }
                            }
                            
                            using (var fs = File.Create(filePath))
                            {

                                try
                                {
                                    if (workbook is XSSFWorkbook)
                                    {
                                        XSSFWorkbook b = (XSSFWorkbook)workbook;
                                        POIXMLProperties props = b.GetProperties();
                                        props.CoreProperties.Creator = "Macrobo";

                                    }
                                }
                                catch (Exception){}

                                workbook.Write(fs);
                                workbook.Close();
                            }
                        }
                        break;
                    case FileOutputType.上書き:
                        {
                            for (int r = 0; r < ValueList.Count; r++)
                            {
                                IRow row = sheet.CreateRow(r);
                                for (int c = 0; c < ValueList[r].Count; c++)
                                {
                                    ICell cell = row.CreateCell(c);
                                    cell.SetCellValue(ValueList[r][c]);
                                }
                            }
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }
                            using (var fs = File.Create(filePath))
                            {
                                try
                                {
                                    if (workbook is XSSFWorkbook)
                                    {
                                        XSSFWorkbook b = (XSSFWorkbook)workbook;
                                        POIXMLProperties props = b.GetProperties();
                                        props.CoreProperties.Creator = "Macrobo";

                                    }
                                }
                                catch (Exception) { }
                                workbook.Write(fs);
                                workbook.Close();
                            }
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 配列を指定の値で、指定要素分初期化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static List<string> GetNewStringList(string value, int columnCount)
        {
            try
            {
                return Enumerable.Repeat(value, columnCount).ToList(); ;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// リストから2次元配列へ変換する
        /// </summary>
        public void ListToArray()
        {
            try
            {
                Value = null;
                if (ValueList.Count > 0)
                {
                    Value = new string[ValueList.Count][];
                    for(int i = 0; i < ValueList.Count; i++)
                    {
                        Value[i] = ValueList[i].ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 2次元配列からリストへ変換する
        /// </summary>
        public void ArrayToList()
        {
            try
            {
                ValueList = new List<List<string>>();
                if(Value != null)
                {
                    for(int i = 0; i < Value.Length; i++)
                    {
                        List<string> list = new List<string>();
                        for(int j = 0; j < Value[i].Length; j++)
                        {
                            list.Add(Value[i][j]);
                        }
                        ValueList.Add(list);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
