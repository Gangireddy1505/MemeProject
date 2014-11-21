using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Meme.Data;
using System.Web.Http.Routing;
using System.Net.Http;


namespace Meme.Web.Models
{
    public class ModelFactory
    {
        private UrlHelper _UrlHelper;
        private IMemeRepository _repo;

        public ModelFactory(HttpRequestMessage request, IMemeRepository repo)
        {
            _UrlHelper = new UrlHelper(request);
            _repo = repo;
        }


        public MemeModel Create(Data.Meme meme)
        {
            return new MemeModel()
            {
                //Url = _UrlHelper.Link("Courses", new { id = course.Id }),
                Id = meme.Id,
                Title = meme.Title ,
                Description = meme.Description,
                ImageUrl = meme.ImageUrl,
                Genre = meme.Genre
            };
        }

        public Data.Meme Parse(MemeModel model)
        {
            try
            {
                var meme = new Data.Meme()
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Genre = model.Genre,
                    
                };

                return meme;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}