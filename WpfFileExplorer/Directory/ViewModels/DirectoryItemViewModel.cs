﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfFileExplorer
{
    /// <summary>
    /// A view model of each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Property
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name
        {
            get
            {
                return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderPath(this.FullPath).ToString();
            }
        }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        public bool IsExpanded
        {
            get
            {
               return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                    this.Expand();
                else
                    this.ClearChildren();
            }
        }
        #endregion

        #region Public Commans

        /// <summary>
        /// The command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor

        public DirectoryItemViewModel(string fullpath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);
            this.FullPath = fullpath;
            this.Type = type;
            this.ClearChildren();
        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// Clear list of children 
        /// </summary>
        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }
        #endregion

        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
