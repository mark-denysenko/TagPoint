using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vote
{
    public class VoteEntity
    {
        public long UserId { get; set; }
        public int PostId { get; set; }
        public bool Like { get; set; }
    }
}
