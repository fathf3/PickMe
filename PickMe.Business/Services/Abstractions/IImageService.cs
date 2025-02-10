using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Business.Services.Abstractions
{
    public interface IImageService
    {
        Task<string> UploadSurveyImageAsync(IFormFile imageFile);
    }
}
