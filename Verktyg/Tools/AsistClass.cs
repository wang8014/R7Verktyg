using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Verktyg.Tools
{
    /// <summary>
    /// Threading parameter for analysis of nameconflict
    /// </summary>
    public class NameConflictParameter : ICloneable
    {
        public string OriginalDirectory { get; set; }
        public string OriginalExtension { get; set; }
        public string DestinationExtension { get; set; }

        public bool IsShowFolder { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public NameConflictParameter()
        {
            OriginalDirectory = "";
            DestinationExtension = "";
            OriginalExtension = "";
            IsShowFolder = false;
        }
    }
    /// <summary>
    /// Threading parameter for Copy File
    /// </summary>
    public class CopyFileParameter : ICloneable
    {
        public string OriginalDirectory { get; set; }
        public string OutoutDirectoy { get; set; }
       
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public CopyFileParameter()
        {
            OriginalDirectory = "";
            OutoutDirectoy = "";
            
        }
    }
    /// <summary>
    /// Threading parameter for Delete File
    /// </summary>
    public class DeleteFileParameter : ICloneable
    {
        public string OutoutDirectoy { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public DeleteFileParameter()
        {
            OutoutDirectoy = "";

        }
    }
    /// <summary>
    /// Threading parameter for Check file
    /// </summary>
    public class CheckFileParameter : ICloneable
    {
        public string OriginalExtension { get; set; }
        public string OutputFileExtension { get; set; }
        public string OriginalDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public string AllExtensionOfLibreOfficeSupporting { get; set; }



        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public CheckFileParameter()
        {
            OriginalDirectory = "";
            OriginalDirectory = "";
            OutputFileExtension = "";
            OutputDirectory = "";
            AllExtensionOfLibreOfficeSupporting = "";
        }
    }
    /// <summary>
    /// Log parameter of print Name Conflict
    /// </summary>
    public class NameConflictResult
    {
        public string NameConflictFileName { get; set; }
        public string ExtensionName { get; set; }
        public string OriginalFileName { get; set; }
        public string Path { get; set; }
        public NameConflictResult()
        {
            NameConflictFileName = "";
            ExtensionName = "";
            OriginalFileName = "";
            Path = "";
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

     
    /// <summary>
    /// Log parameter of print Check Files Result
    /// </summary>
    public class CheckResult
    {
        public long OriginalFileSize { get; set; }
        public long DestinationFileSize { get; set; }

        public string OriginalPath { get; set; }
        public string DestinationPath { get; set; }
        public string OriginalExtension { get; set; }
        public string DestinationExtension { get; set; }
        public string OriginalFileNameWithExtension { get; set; }
        public string DestinationFileNameWithExtension { get; set; }

        
        
        public bool isValid
        {
            //get
            //{
            //    return OriginalFileNameWithExtension == DestinationFileNameWithExtension ? true : false;
            //}
            get;set;
        }
        public CheckResult()
        {
            OriginalPath = "";
            DestinationPath = "";
            OriginalExtension = "";
            DestinationExtension = "";
            OriginalFileNameWithExtension = "";
            DestinationFileNameWithExtension = "";
            isValid = false;
            
        }
    }
    /// <summary>
    /// Threading parameter For converting of officedocuments with LibreOffice
    /// </summary>
    public class LibreOfficeParameter : CheckFileParameter
    {
        public string Path { get; set; }
        public string Command { get; set; }
        public bool IsincludSubfolder { get; set; }
        public bool Isoverwrite { get; set; }

        public string BatchFile { get; set; }
        
        public new object Clone()
        {
            return this.MemberwiseClone();
        }



        public LibreOfficeParameter()
        {
            Path = "";
            Command = "";
            IsincludSubfolder = false;
            Isoverwrite = false;
            BatchFile = "";


        }

    }

    /// <summary>
    /// Original and Destination File. They are always a pair.
    /// </summary>
    public class PairFile:ICloneable
    {
        //subfolder where copy original file to.
        public const string PreName = "rename_";
        public FileInfo originalFile { get; set; }
        public string outputDir { get; set; }
        public string outputFileName {
            get
            {
                if (IsRename)
                {
                    return Path.GetFileNameWithoutExtension(GetSerialNumberFileName()) + "." + outputFileExtension;
                }else
                {
                    return GetDefaultOutputFileName();
                }
            }
        }

        public string outputFileExtension { get; set; }

        public byte serialNumber { get; set; }

        public bool IsRename { get;set;
            //get
            //{
            //    if (originalFile != null) { 
            //        if (Path.GetFileNameWithoutExtension(outputFileName) == Path.GetFileNameWithoutExtension(originalFile.Name))
            //        {
            //            return false;
            //        }
            //        else { return true; }
            //    }
            //    else
            //    {
            //        //FileInfo is null,return false. No rename
            //        return false;
            //    }
            //}
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public PairFile(string fileFullName)
        {
            originalFile = new FileInfo(fileFullName);
            //outputFileName = "";

            outputDir = "";
            outputFileExtension = "pdf";// this is default extension
            serialNumber = 1;
            IsRename = false;
        }
        /// <summary>
        /// return default outputfileName 
        /// default outputfileName = Withoutextension(originalFile.Name) + outputFileExtension(".pdf")
        /// If IsRename is true.  default outputfileName is not same with originalFile
        /// </summary>
        /// <returns></returns>
        public string GetDefaultOutputFileName()
        {
            return Path.GetFileNameWithoutExtension(originalFile.Name) + "." + outputFileExtension;
        }
        ///// <summary>
        ///// According to SerialNumber ,to create a new file. return this new file's name
        ///// FileName doesn't include path
        ///// </summary>
        ///// <returns></returns>
        //public string GetSerialNumberFileName()
        //{
        //    if (IsRename) {
        //        return PreName + GetSerialNumberFileNameWithoutPreName();
        //    } else
        //    {
        //        return originalFile.Name;
        //    }
        //}
        private string GetSerialNumberFileName()  // WithoutPreName()
        {
            if (IsRename)
            {
                string extension = Path.GetExtension(originalFile.Name);
                if (extension.IndexOf(".") >= 0)
                {
                    extension = extension.Substring(extension.IndexOf(".") + 1);
                }
                string newName = Path.GetFileNameWithoutExtension(originalFile.Name) + "_" + extension + "_" + this.serialNumber.ToString() + "." + extension;

                return newName;
            }
            else
            {
                return originalFile.Name;
            }
        }
        /// <summary>
        /// Get right file name that will be converted.
        /// This name include path
        /// Create a subfolder for pdf -> pdf , originalfile and  outputfile is completely same.
        /// use subfolder kan avoid same name files in same directory problem 
        /// </summary>
        /// <returns></returns>
        public string GetRightOriginalName()
        {
            if (IsRename)
            {
                return outputDir + "\\" + PreName + "\\" + GetSerialNumberFileName();
            }
            else
            {
                return originalFile.FullName;
            }
        }
        /// <summary>
        /// Copy a new file from original file to the outputdir
        /// </summary>
        public void CreateSerialNumberFile()
        {
            if (!IsRename)
            {
                return;
            }
            //delete the wrong name's outputfile
            if (System.IO.File.Exists(GetDefaultOutputFileName()))
            {
                // Delete this file because this converting file is renamed.
                // Delete the wrong name file and convert again to ensure the converting file is newest.
                System.IO.File.Delete(GetDefaultOutputFileName());
            }
            if (!System.IO.Directory.Exists(outputDir + "\\" + PreName))
            {
                System.IO.Directory.CreateDirectory(outputDir + "\\" + PreName);
            }
            // delete the serialname file for copy again.
            if (System.IO.File.Exists(GetRightOriginalName()))
            {
                //if the SerialNumber file is exists ,delete it first and then copy again.
                System.IO.File.Delete(GetRightOriginalName());
                            
            }
            
            //Copy a new file
            System.IO.File.Copy(originalFile.FullName, GetRightOriginalName());
        }

        public void DeleteSerialNumberFile()
        {
            System.IO.File.Delete(GetRightOriginalName());
            //ReNameOutputFile();
            if (System.IO.Directory.GetFiles(outputDir + "\\" + PreName).Count() == 0){
                System.IO.Directory.Delete(outputDir + "\\" + PreName);
            }
        }

        //private void ReNameOutputFile()
        //{
        //    System.IO.File.Move(outputDir + "\\" + outputFileName, outputDir + "\\" + GetSerialNumberFileNameWithoutPreName());
        //}
    }
    /// <summary>
    /// Custom EqualityComparer Class
    /// </summary>
    public class FileInfoComparer : IEqualityComparer<FileInfo>
    {
        // FileInfo are equal if their fullname and length are equal.
        public bool Equals(FileInfo x, FileInfo y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the FileInfo' properties are equal.
            //Console.WriteLine("x=" + x.FullName + " " + x.Length.ToString() ) ;
            //Console.WriteLine("y=" + y.FullName + " " + x.Length.ToString() );
            return ((x.FullName.Trim().ToLower() == y.FullName.Trim().ToLower()) && (x.Length == y.Length));
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(FileInfo item)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(item, null)) return 0;

            //Get hash code for the FullName field if it is not null.
            int hashFileName = item.FullName == null ? 0 : item.FullName.GetHashCode();

            //Get hash code for the Length field.
            int hashFileLength = item.Length.GetHashCode();

            //Calculate the hash code for the FileInfo.
            return hashFileName ^ hashFileLength;
        }

    }

}
