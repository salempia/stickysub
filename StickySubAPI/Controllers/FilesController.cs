using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace StartupBusStickySub.Controllers
{
    public class UserModel
    {
       public string Name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }

    }
    /// <summary>
    /// An example of a controller to upload files to demonstrate the request size limit setting (https://www.talkingdotnet.com/how-to-increase-file-upload-size-asp-net-core/)
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class FilesController: ControllerBase
    {
        /// <summary>
        /// Upload a file
        /// </summary>
        /// <remarks>
        /// Play around with file size. Try to upload a file more 1048576 bytes length
        /// </remarks>
        /// <param name="file">A file to upload</param>
        [HttpPost]
        [Route("upload")]
        [RequestSizeLimit(1048576)]
        
        public Task<IActionResult> Upload(IFormFile file)
        {


            if (file.Length <= 0)
                return Task.FromResult<IActionResult>(BadRequest("Empty file"));

            //Strip out any path specifiers (ex: /../)
            var originalFileName = Path.GetFileName(file.FileName);

            
            //Save the file to disk
            using (var stream = System.IO.File.Create("Result.csv"))
            {
                 file.CopyToAsync(stream);
            }

            return Task.FromResult<IActionResult>(Ok($"Saved file {originalFileName} with size {file.Length / 1024m:#.00} KB"));

            // return Task.FromResult<IActionResult>(Ok($"Uploaded: {file.FileName}"));
        }
        //public List<string> Index(IFormFile file) => file.ReadAsList();
    }
}
