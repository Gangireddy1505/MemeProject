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
    public class BaseController : ApiController
    {
        private ModelFactory _modelFactory;
        private IMemeRepository _repo;

        public BaseController(IMemeRepository repo)
        {
            _repo = repo;
        }

         protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request,_repo);
                }
                return _modelFactory;
            }
        }

          protected IMemeRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }



    }
}
