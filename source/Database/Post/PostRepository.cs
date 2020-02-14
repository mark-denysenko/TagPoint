using Domain.Post;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    public class PostRepository : EntityFrameworkCoreRelationalRepository<PostEntity>, IPostRepository
    {
        public PostRepository(Context context) : base(context)
        {
            //var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            //var currentLocation = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-122.121512, 47.6739882));
        }


    }
}
