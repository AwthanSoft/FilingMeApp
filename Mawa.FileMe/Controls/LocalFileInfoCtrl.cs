using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Mawa.FileMe.Controls
{
    public class LocalFileInfoCtrl : INotifyPropertyChanged
    {
        #region Bindings

        public string FileName
        {
            get { return Path.GetFileNameWithoutExtension(FilePath); }
        }
        public string FileExtension
        {
            get { return Path.GetExtension(FilePath); }
        }
        public string FileDir
        {
            get 
            {
                if (FilingInfo != null)
                    return FilingInfo.DirectoryName;
                return string.Empty;
            }
        }
        public long FileSize
        {
            get 
            { 
                if(FilingInfo != null)
                    return FilingInfo.Length;
                return 0;
            }
        }
        public bool Exist
        {
            get
            {
                return File.Exists(FilePath);
            }
        }
        public string HashMD5File
        {
            get
            {
                if(Exist)
                    return Mawa.Hash.ComputeHash.GetHash_MD5(FilePath);
                return null;
            }
        }

        #endregion

        #region Initial
        internal LocalFileInfoCtrl()
        {

        }
        public LocalFileInfoCtrl(string FilePath)
        {
            this.FilePath = FilePath;
            FilingInfo = new FileInfo(this.FilePath);
        }

        #endregion

        #region Filing Ctrl

        FileInfo _FilingInfo;
        public FileInfo FilingInfo
        {
            get
            {
                if (_FilingInfo == null)
                {
                    if (Exist)
                    {
                        _FilingInfo = new FileInfo(FilePath);
                    }
                    else
                    {
                        //throw new NullReferenceException();
                    }
                }
                return _FilingInfo;
            }
            private set
            {
                _FilingInfo = value;
                OnPathChanged(nameof(FilingInfo));
            }
        }

        string _FilePath = string.Empty;
        public string FilePath
        {
            get => _FilePath;
            set
            {
                changeFile(value);
                //_FilePath = value;
                //OnPropertyChanged(nameof(FilePath));
            }
        }
        public void changeFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                _FilingInfo = null;
                _FilePath = string.Empty;
            }
            else
            {
                _FilingInfo = null;
                _FilePath = filePath;
            }
            OnPathChanged(FilePath);
            NotifyChangedAllProperties();
        }
        
        #endregion

        #region INotify fire
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual void NotifyChangedAllProperties()
        {
            var tt = this.GetType().GetProperties();
            foreach (var pro in tt)
            {
                OnPropertyChanged(pro.Name);
            }
        }
        #endregion

        #region FileType
        FileTypeEnum _FileType = FileTypeEnum.Unknown;
        public FileTypeEnum FileType
        {
            get => _FileType;
            set
            {
                _FileType = value;
                OnPathChanged(nameof(FileType));
            }
        }
        #endregion

        #region Events

        public event EventHandler<string> PathChanged;
        protected virtual void OnPathChanged(string changedPath)
        {
            if (PathChanged != null)
            {
                PathChanged?.Invoke(this, changedPath);
            }
        }

        #endregion
    }
}
