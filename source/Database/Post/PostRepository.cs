using Domain.Post;
using DotNetCoreArchitecture.Database;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Post
{
    public class PostRepository : DotNetCore.EntityFrameworkCore.EntityFrameworkCoreRelationalRepository<PostEntity>, IPostRepository
    {
        private Context Context { get; set; }

        public IQueryable<PostEntity> Posts => Context.Posts;

        public PostRepository(Context context) : base(context)
        {
            Context = context;
            //var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            //var currentLocation = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-122.121512, 47.6739882));
        }
    }
}
