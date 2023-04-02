namespace cqrs_vhec.Helper
{
    public static class FilesHelper
    {

        public static string UploadFileAndReturnPath(IFormFile file, string root, string childFolder, bool saveInWwwRoot = true)
        {
            //var root = saveInWwwRoot ? _host.WebRootPath : _host.ContentRootPath;
            var filename = Path.GetFileNameWithoutExtension(file.FileName)
                            + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff")
                            + Path.GetExtension(file.FileName);
            if (!Directory.Exists(root + childFolder))
            {
                Directory.CreateDirectory(root + childFolder);
            }
            var relativePath = childFolder + filename;
            var path = root + relativePath;
            var x = new FileStream(path, FileMode.Create);
            file.CopyTo(x);
            x.Dispose();
            GC.Collect();
            return relativePath;
        }

    }


}
