using System;

public class Vote
{
    public int VoteID { get; set; }
    public int UserID { get; set; }
    public int? PostID { get; set; }
    public int? CommentID { get; set; }
    public int VoteType { get; set; } // -1 for downvote, 1 for upvote
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public virtual User User { get; set; }
    public virtual Post Post { get; set; }
    public virtual Comment Comment { get; set; }
}
