namespace AssemblyBrowser.Interfaces
{
    interface IFileWorker
    {
        void ShowMessage(string message);
        string FilePath { get; set; }
        bool OpenFileD();
        bool SaveFileD();
    }
}
