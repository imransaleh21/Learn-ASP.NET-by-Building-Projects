using SharedFiles;
using ServiceBluePrints;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
namespace Services
{
    public class SocialMediaService: ISocialMediaService
    {
        private readonly ConfigurationOptions _options;
        private readonly IHostEnvironment _environment;
        public SocialMediaService
            (
            IOptions<ConfigurationOptions> options,
            IHostEnvironment env
            )
        {
            _options = options.Value;
            _environment = env;
        }

        public SocialMediaLinks GetSocialMEdiaLinks()
        {
            SocialMediaLinks socialMedia = new()
            {
                Facebook = _options.Facebook,
                Youtube = _options.Youtube,
                Twitter = _options.Twitter,
                Instagram = (!_environment.IsDevelopment()) ? _options.Instagram : null
            };
            return socialMedia;
        }
    }
}
