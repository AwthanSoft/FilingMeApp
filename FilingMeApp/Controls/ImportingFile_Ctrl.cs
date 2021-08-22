using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Linq;
using FilingMeApp.Filters;

namespace FilingMeApp.Controls
{
    public abstract class ImportingFileCtrlCore : IDisposable, INotifyPropertyChanged
    {
        #region Initial

        public ImportingFileCtrlCore()
        {
            pre_initial();
        }

        private void pre_initial()
        {
            pre_initial_FileInfoCtrl();
            pre_initial_PathCtrl();
            pre_Initial_FilterCtrl();
            pre_initial_SaveCtrl();

        }

        #endregion

        #region FileInfo

        public LocalFileInfoCtrl FileInfoCtrl { private set; get; }
        void pre_initial_FileInfoCtrl()
        {
            FileInfoCtrl = new LocalFileInfoCtrl();
        }

        #endregion

        #region PathCtrl
        private void pre_initial_PathCtrl()
        {

        }
        public void Change_Path(string CurrentPath)
        {
            this.FileInfoCtrl.changeFile(CurrentPath);
        }

     

        #endregion


        #region Filter

        string _GeneralFilter;
        public string GeneralFilter
        {
            get
            {
                if (string.IsNullOrEmpty(_GeneralFilter))
                    return GeneralFileFilters.AllFilesFilter_Default;
                return _GeneralFilter;
            }

            set
            {
                _GeneralFilter = value;
                OnPropertyChanged(nameof(GeneralFilter));
            }
        }

        private void pre_Initial_FilterCtrl()
        {

        }


        public void SetGeneralFilter(FileTypeEnum FileType, bool IncludeAllFileFilterPart = true)
        {
            GeneralFilter = GeneralFileFilters.GetFilterByFileType(FileType, IncludeAllFileFilterPart);
        }

        #endregion

        #region Importing
        public abstract void ImportFile_Dialog();

        #endregion


        #region extra Settings
        string MessageError = " Please Select Correct File Type !";
        string[] validExtensions;

        int filterIndex = 0;
        public int FilterIndex
        {
            set { filterIndex = value; }
            get { return filterIndex; }
        }

        public bool IsValidExtension(string ext)
        {
            if (validExtensions == null)
                return true;

            return validExtensions.Contains(ext.Replace(".", "").ToLower());
        }

        public void set_MessageErrorImport(string MessageError)
        {
            this.MessageError = MessageError;
        }
        //public void set_generalFilter(string generalFilter)
        //{
        //    this.GeneralFilter = generalFilter;
        //}
        public void set_validExtensions(string[] _validExtensions)
        {
            this.validExtensions = _validExtensions;
        }
        public void Set_FilterIndex(int FilterIndex)
        {
            this.FilterIndex = FilterIndex;
        }

        #endregion

        #region For Save

        public bool isDone { private set; get; }
        public bool isCancel { private set; get; }

        public bool errorSave { private set; get; }

        void pre_initial_SaveCtrl()
        {
            isDone = false;
            isCancel = false;
            errorSave = false;
        }

        public void Cancel()
        {
            isDone = false;
            isCancel = true;
        }

        public bool Done()
        {
            if (isCancel || !FileInfoCtrl.Exist)
            {
                errorSave = true;
                throw new Exception();
            }
            else
            {
                isDone = true;
            }
            return isDone;
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

        #region Dispose
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
            }

            // Free any unmanaged objects here.

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ImportingFileCtrlCore()
        {
            Dispose(false);
        }

        #endregion
    }
}
