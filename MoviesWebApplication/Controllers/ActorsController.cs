using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApplication.Data;
using MoviesWebApplication.ResponseObjects;

namespace MoviesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private Context _ctx;
        public ActorsController(Context context)
        {
            _ctx = context;
        }

        [HttpGet]
        public ActorsListResponse GetActors()
        {
            var resp = new ActorsListResponse();
            var actors = _ctx.Actors;
            resp.TotalResults = actors.Count();
            resp.Actors = actors.Select(x => new ActorListItem()
            {
                ActorId = x.ActorId,
                ActorName = x.ActorName,
                ActorDOB = x.ActorDOB,
                ActorDOD = x.ActorDOD
            }).ToList();

            return resp;
        }
    }
}