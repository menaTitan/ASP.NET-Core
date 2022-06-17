using Microsoft.AspNetCore.Components.Forms;

namespace File_Upload.Services
{
    public interface IFileUpload
    {
        Task Uploadfile(IBrowserFile file);
        Task<string> GeneratePreviewUrl(IBrowserFile file);
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

       public async  Task<string> GeneratePreviewUrl(IBrowserFile file)
        {
            if (!file.ContentType.Contains("image"))
            {
                if (file.ContentType.Contains("pdf")) 
                {
                    return "images/pdf_logo.png";
                }
            }

            var resizedImage = await file.RequestImageFileAsync(file.ContentType, 100, 100);
            var buffer = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(buffer);

            return $"data: {file.ContentType}; base64,{Convert.ToBase64String(buffer)}";
        }
    }
}
