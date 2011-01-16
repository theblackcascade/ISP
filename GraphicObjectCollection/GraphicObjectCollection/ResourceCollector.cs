using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.IO;

namespace GraphicObjectCollection
{
    class ResourceCollector: IDisposable
    {

        private readonly FileSystemWatcher _fileSystemWatcher;
        private readonly StateManager _stateManager;
   
        ResourceCollector(string path,string filter, StateManager stateManager)
        {
            _fileSystemWatcher = new FileSystemWatcher(path,filter);

            _stateManager = new StateManager(null);
        }

        public void Handle()
        {
            _fileSystemWatcher.Created += (o,e) => _stateManager.LoadState();
        }

        public void Dispose()
        {
            _fileSystemWatcher.Dispose();
        }
    }
}
