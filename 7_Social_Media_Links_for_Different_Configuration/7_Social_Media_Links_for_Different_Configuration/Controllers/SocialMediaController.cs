using Microsoft.AspNetCore.Mvc;
using ServiceBluePrints;
using SharedFiles;

namespace _7_Social_Media_Links_Using_Different_Configuration.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaController(
            ISocialMediaService socialMediaService
            )
        {
            _socialMediaService = socialMediaService;
        }
        [Route("/")]
        public IActionResult Home()
        {
            SocialMediaLinks res = _socialMediaService.GetSocialMEdiaLinks();
            return Json(res);
        }
    }
}
