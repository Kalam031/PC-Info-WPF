using SidePanel_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class StorageViewModel : ViewModelBase
    {
        List<DiskDriveModel> listDiskDriveInfo;
        List<DiskDrivePartitionModel> listDiskPartionInfo;

        public List<DiskDriveModel> ListDiskDriveInfo
        {
            get => PcInfoViewModel.ListDiskDriveInfo;
            set
            {
                listDiskDriveInfo = value;
                OnPropertyChanged(nameof(ListDiskDriveInfo));
            }
        }


        public List<DiskDrivePartitionModel> ListDiskPartionInfo
        {
            get => PcInfoViewModel.ListDiskDrivePartitionInfo;
            set
            {
                listDiskPartionInfo = value;
                OnPropertyChanged(nameof(ListDiskPartionInfo));
            }
        }
    }
}
