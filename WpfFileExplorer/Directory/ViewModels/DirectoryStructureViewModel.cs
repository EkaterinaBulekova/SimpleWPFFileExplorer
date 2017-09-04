using System.Collections.ObjectModel;
using System.Linq;

namespace WpfFileExplorer
{
    /// <summary>
    /// The view model for the applications main Directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        
        #endregion

        #region Constructor

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();

            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                             children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));               
                    
        }

        #endregion
    }
}
