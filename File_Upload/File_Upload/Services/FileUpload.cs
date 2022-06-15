using Microsoft.AspNetCore.Components.Forms;

namespace File_Upload.Services
{
    public interface IFileUpload
    {
        Task Uploadfile(IBrowserFile file);
    }
    public class FileUpload : IFileUpload
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileUpload> _logger;
        public FileUpload(IWebHostEnvironment webHostEnvironment, ILogger<FileUpload> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        public  async Task Uploadfile(IBrowserFile file)
        {
            if (file is not null) 
            {
                try
                {
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.Name);
                    //maxAllowedSize:122222222 -> allowed to upload bigger size file
                    using (var stram = file.OpenReadStream(maxAllowedSize:122222222))
                    {
                        var fileStream = File.Create(uploadPath);

                        await stram.CopyToAsync(fileStream);

                        fileStream.Close();
                    }
                }
                catch (Exception e)
                {

                    _logger.LogError(e.ToString()); ;
                }
            
            }
        }
    }
}
