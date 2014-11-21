using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Meme.Data;
using Meme.Web.Models;

namespace Meme.Web.Controllers
{
    public class MemeController : BaseController
    {
        public MemeController(IMemeRepository repo)
            : base(repo)
        {
        }

        public IEnumerable<MemeModel> Get()
        {
            IMemeRepository repository = new MemeRepository(new MemeContext());

            IQueryable<Data.Meme> query;
            query = TheRepository.GetAllMemes();

            var results = query.ToList().Select(s => TheModelFactory.Create(s));

            return results;

        }

        public HttpResponseMessage GetMeme(int id)
        {
            try
            {
                var meme = TheRepository.GetMeme(id);

                if (meme != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(meme));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody] MemeModel memeModel)
        {
            try
            {
                var entity = TheModelFactory.Parse(memeModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read meme");

                if (TheRepository.InsertMeme(entity) && TheRepository.Save())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Put(int Id, [FromBody] MemeModel memeModel)
        {
            try
            {
                var updatedMeme = TheModelFactory.Parse(memeModel);

                if (updatedMeme == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Could not read meme from body");
                var originalMeme = TheRepository.GetMeme(Id);
                if (originalMeme == null || originalMeme.Id != Id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Meme Not Found");
                }
                else
                {
                    updatedMeme.Id = Id;
                }

                if (TheRepository.UpdateMeme(originalMeme, updatedMeme) && TheRepository.Save())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(updatedMeme));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var meme = TheRepository.GetMeme(id);

                if (meme == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

               

                if (TheRepository.DeleteMeme(id) && TheRepository.Save())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



    }
}
