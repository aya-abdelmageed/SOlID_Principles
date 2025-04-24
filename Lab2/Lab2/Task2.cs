using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // 2. Client need to build an application to manage data using group of SQL files.
    // a. we need to develop load text and save text functionalities for group of SQL files in the application directory.
    // b. we need a manager class that manages the load and saves the text of group of SQL files along with the SqlFile Class.

    /// <summary>
    /// Interfaces for File Operations
    /// </summary>

    public interface IReadFile
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }
        string LoadText();
    }

    public interface IWriteFile : IReadFile
    {
        string SaveText();
    }

    public class SqlFile : IWriteFile
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }
        public string LoadText()
        {
            /* Code to read text from sql file */
            if (File.Exists(FilePath))
            {
                return FileText = File.ReadAllText(FilePath);
            }
            return String.Empty;
        }
        public string SaveText()
        {
            /* Code to save text into sql file */
            File.WriteAllText(FilePath, FileText);
            return FilePath;
        }
    }



    //public class SqlFileManager
    //{
    //    public List<SqlFile> lstSqlFiles { get; set; }

    //    public string GetTextFromFiles()
    //    {
    //        StringBuilder objStrBuilder = new StringBuilder();
    //        foreach (var objFile in lstSqlFiles)
    //        {
    //            objStrBuilder.Append(objFile.LoadText());
    //        }
    //        return objStrBuilder.ToString();
    //    }
    //    public void SaveTextIntoFiles()
    //    {
    //        foreach (var objFile in lstSqlFiles)
    //        {
    //            objFile.SaveText();
    //        }
    //    }
    //}

    // c. New Requirement:
    // After some time our leaders might tell us that we may have a few read-only files in the application folder, 
    // so we need to restrict the flow whenever it tries to do a save on them.

    public class ReadOnlySqlFile : IReadFile
    {
        public string FilePath { get; }
        public string FileText { get; private set; }
        string IReadFile.FilePath { get => FilePath; set => throw new NotImplementedException(); }
        string IReadFile.FileText { get => FileText; set => FileText = value; }

        public string LoadText()
        {
            if (File.Exists(FilePath))
            {
                return FileText = File.ReadAllText(FilePath);
            }
            return string.Empty;
        }

    }

    // d. To avoid an exception we need to modify "SqlFileManager" by adding one condition to the loop.
    public class SqlFileManager
    {
        private readonly IEnumerable<IReadFile> _sqlFiles;

        public SqlFileManager(IEnumerable<IReadFile> sqlFiles)
        {
            _sqlFiles = sqlFiles;
        }
        public string GetTextFromFiles()
        {
            StringBuilder objStrBuilder = new StringBuilder();
            foreach (var objFile in _sqlFiles)
            {
                objStrBuilder.Append(objFile.LoadText());
            }
            return objStrBuilder.ToString();
        }
        public void SaveTextIntoFiles()
        {
            foreach (var objFile in  _sqlFiles.OfType<IWriteFile>() )
            {
                    objFile.SaveText();
            }
        }
    }


}
