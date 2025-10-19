namespace FileUploaderWebApi.PublicClasses
{
    public class UploadHandler
    {
        public UploadStatus UploadFile(IFormFile file)
        {
            UploadStatus result = new UploadStatus();
            //extention
            List<string> allowedExtensions = new List<string> { ".jpg", ".png", ".gif" };
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                result.IsSuccess = false;
                result.Message = $"Extention is not valid ({string.Join(',', allowedExtensions)})";
                return result;
            }

            //file size
            long maxFileSize = 5 * 1024 * 1024; // 5 MB
            if (file.Length > maxFileSize)
            {
                result.IsSuccess = false;
                result.Message = "Maximun size can be 5mb";
                return result;
            }

            //name changing
            result.fileName = $"{Guid.NewGuid()}{fileExtension}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads");

            try
            {
                using FileStream stream = new FileStream(Path.Combine(filePath, result.fileName), FileMode.Create);
                file.CopyTo(stream);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Hubo un error al guardar el archivo";
                return result;
            }

            return result;
        }
    }
}
